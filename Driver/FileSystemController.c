#include "FileSystemController.h"


#define PRE_ROUTINE_IS_READ_OPERATION ( \
	(data->Iopb->MajorFunction == IRP_MJ_READ) \
)

#define PRE_ROUTINE_IS_WRITE_OPERATION ( \
	(data->Iopb->MajorFunction == IRP_MJ_CREATE) && \
	(data->Iopb->Parameters.Create.SecurityContext->DesiredAccess & (FILE_WRITE_DATA | FILE_APPEND_DATA)) \
)

#define PRE_ROUTINE_IS_MOVE_OPERATION ( \
	(data->Iopb->MajorFunction == IRP_MJ_CREATE) || \
	(data->Iopb->MajorFunction == IRP_MJ_SET_INFORMATION) \
)

#define PRE_ROUTINE_BLOCK_ACCESS(_access_type_) \
do \
{ \
	data->IoStatus.Status = STATUS_UNSUCCESSFUL; \
	data->IoStatus.Information = 0; \
	ret_callback_status = FLT_PREOP_COMPLETE; \
	AgentControllerShowAccessBlockedToast(PsGetCurrentProcessId(), _access_type_); \
	goto CLEANUP; \
} while (0);


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
	_Out_	PVOID					*completion_context
)
{
	UNREFERENCED_PARAMETER(flt_object);
	UNREFERENCED_PARAMETER(completion_context);

	FLT_PREOP_CALLBACK_STATUS ret_callback_status = FLT_PREOP_SUCCESS_WITH_CALLBACK;
	PFLT_FILE_NAME_INFORMATION file_name_info = NULL;
	NTSTATUS status = STATUS_SUCCESS;

	if (data->RequestorMode != UserMode || KeGetCurrentIrql() != PASSIVE_LEVEL || !FLT_IS_IRP_OPERATION(data))
		goto CLEANUP;


	status = FltGetFileNameInformation(
		data,
		FLT_FILE_NAME_NORMALIZED |
		FLT_FILE_NAME_QUERY_DEFAULT,
		&file_name_info
	);
	if (!NT_SUCCESS(status))
	{
		ret_callback_status = FLT_PREOP_SUCCESS_NO_CALLBACK;
		goto CLEANUP;
	}

	status = FltParseFileNameInformation(file_name_info);
	if (!NT_SUCCESS(status))
	{
		ret_callback_status = FLT_PREOP_SUCCESS_NO_CALLBACK;
		goto CLEANUP;
	}

	HANDLE process_id = PsGetCurrentProcessId();
	if (process_id == NULL)
		goto CLEANUP;
	
	if (!ContainerControllerIsAllowAccessProcessIdToPath(process_id, &(file_name_info->Name)))
	{
		ACCESS_TYPE access_type = READ_FILE;

		if (PRE_ROUTINE_IS_WRITE_OPERATION)
			access_type = WRITE_FILE;
		if (PRE_ROUTINE_IS_MOVE_OPERATION)
			access_type = MOVE_FILE;

		PRE_ROUTINE_BLOCK_ACCESS(access_type);
	}

	UINT32 permission = AccessControllerGetPermissionByProcessId(process_id);
	if (permission == (UINT32)0xffffffff)
		goto CLEANUP;

	/* Read File */
	if ((PRE_ROUTINE_IS_READ_OPERATION) && (!IS_ALLOW_ACCESS(permission, READ_FILE)))
	{
		PRE_ROUTINE_BLOCK_ACCESS(READ_FILE);
	}
	/* Write File */
	if ((PRE_ROUTINE_IS_WRITE_OPERATION) && (!IS_ALLOW_ACCESS(permission, WRITE_FILE)))
	{
		PRE_ROUTINE_BLOCK_ACCESS(WRITE_FILE);
	}
	/* Move File */
	if ((PRE_ROUTINE_IS_MOVE_OPERATION) && (!IS_ALLOW_ACCESS(permission, MOVE_FILE)))
	{
		if (data->Iopb->MajorFunction == IRP_MJ_CREATE)
		{
			if (data->Iopb->Parameters.Create.Options & FILE_DELETE_ON_CLOSE)
			{
				PRE_ROUTINE_BLOCK_ACCESS(MOVE_FILE);
			}
		}
		else
		{
			switch (data->Iopb->Parameters.SetFileInformation.FileInformationClass)
			{
			case FileRenameInformation:
			case FileRenameInformationEx:
			case FileDispositionInformation:
			case FileDispositionInformationEx:
			case FileRenameInformationBypassAccessCheck:
			case FileRenameInformationExBypassAccessCheck:
				PRE_ROUTINE_BLOCK_ACCESS(MOVE_FILE);
			default:
				break;
			}
		}
	}

	
CLEANUP:
	if (file_name_info)
		FltReleaseFileNameInformation(file_name_info);
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
