#include "FileSystemController.h"


NTSTATUS
FileSystemControllerInitialize()
{
	return FltStartFiltering(g_flt_handle);
}


#pragma warning( push )
#pragma warning( disable:6101 )
FLT_PREOP_CALLBACK_STATUS
MinifltCreatePreRoutine(
	_Inout_	PFLT_CALLBACK_DATA		data,
	_In_	PCFLT_RELATED_OBJECTS	flt_object,
	_Out_	PVOID* completion_context
)
{
	UNREFERENCED_PARAMETER(flt_object);
	UNREFERENCED_PARAMETER(completion_context);

	FLT_PREOP_CALLBACK_STATUS ret_callback_status = FLT_PREOP_SUCCESS_WITH_CALLBACK;
	NTSTATUS status = STATUS_SUCCESS;
	PFLT_FILE_NAME_INFORMATION name_info = NULL;
	UNICODE_STRING process_path; RtlZeroMemory(&process_path, sizeof(process_path));

	if (data->RequestorMode != UserMode || KeGetCurrentIrql() != PASSIVE_LEVEL || !FLT_IS_IRP_OPERATION(data))
		goto CLEANUP;


	status = FltGetFileNameInformation(
		data,
		FLT_FILE_NAME_NORMALIZED |
		FLT_FILE_NAME_QUERY_DEFAULT,
		&name_info
	);
	if (!NT_SUCCESS(status))
	{
		ret_callback_status = FLT_PREOP_SUCCESS_NO_CALLBACK;
		goto CLEANUP;
	}

	status = FltParseFileNameInformation(name_info);
	if (!NT_SUCCESS(status))
	{
		ret_callback_status = FLT_PREOP_SUCCESS_NO_CALLBACK;
		goto CLEANUP;
	}

	HANDLE process_id = PsGetCurrentProcessId();
	if (process_id == NULL)
		goto CLEANUP;
	process_path = GetProcessPathFromProcessId(process_id);
	if (process_path.Buffer == NULL)
	{
		ret_callback_status = FLT_PREOP_SUCCESS_NO_CALLBACK;
		goto CLEANUP;
	}


	UINT32 permission = AccessControllerGetPermission(process_path);
	/* write file */
	if (
		(data->Iopb->MajorFunction == IRP_MJ_CREATE) &&
		(data->Iopb->Parameters.Create.SecurityContext->DesiredAccess & (FILE_WRITE_DATA | FILE_APPEND_DATA)) &&
		(!AccessControllerIsAllowAccess(permission, WRITE_FILE))
	)
	{
		data->IoStatus.Status = STATUS_ACCESS_DENIED;
		data->IoStatus.Information = 0;
		ret_callback_status = FLT_PREOP_COMPLETE;
		goto CLEANUP;
	}

CLEANUP:
	if (name_info)
		FltReleaseFileNameInformation(name_info);
	if (process_path.Buffer)
		RtlFreeUnicodeString(&process_path);
	return ret_callback_status;
}
#pragma warning ( pop )


FLT_POSTOP_CALLBACK_STATUS
MinifltCreatePostRoutine(
	_Inout_		PFLT_CALLBACK_DATA			data,
	_In_		PCFLT_RELATED_OBJECTS		flt_object,
	_In_opt_	PVOID						completion_context,
	_In_		FLT_POST_OPERATION_FLAGS	flags
)
{
	UNREFERENCED_PARAMETER(flt_object);
	UNREFERENCED_PARAMETER(completion_context);
	UNREFERENCED_PARAMETER(flags);
	
	FLT_POSTOP_CALLBACK_STATUS ret_callback_status = FLT_POSTOP_FINISHED_PROCESSING;
	NTSTATUS status = STATUS_SUCCESS;
	PFLT_FILE_NAME_INFORMATION name_info = NULL;


	if (data->RequestorMode != UserMode || KeGetCurrentIrql() != PASSIVE_LEVEL || !FLT_IS_IRP_OPERATION(data))
		goto CLEANUP;


	status = FltGetFileNameInformation(
		data,
		FLT_FILE_NAME_NORMALIZED |
		FLT_FILE_NAME_QUERY_DEFAULT,
		&name_info
	);
	if (!NT_SUCCESS(status))
		goto CLEANUP;

	status = FltParseFileNameInformation(name_info);
	if (!NT_SUCCESS(status))
		goto CLEANUP;

CLEANUP:
	if (name_info != NULL)
		FltReleaseFileNameInformation(name_info);
	return ret_callback_status;
}
