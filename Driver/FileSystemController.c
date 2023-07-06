#include "FileSystemController.h"


NTSTATUS
FileSystemControllerInitialize(
	_In_	PFLT_FILTER		flt_handle
)
{
	return FltStartFiltering(flt_handle);
}


#pragma warning( push )
#pragma warning( disable:6101 )
FLT_PREOP_CALLBACK_STATUS
MinifltCreatePreRoutine(
	_Inout_	PFLT_CALLBACK_DATA		data,
	_In_	PCFLT_RELATED_OBJECTS	flt_object,
	_Out_	PVOID*					completion_context
)
{
	UNREFERENCED_PARAMETER(flt_object);
	UNREFERENCED_PARAMETER(completion_context);

	NTSTATUS status = STATUS_SUCCESS;
	PFLT_FILE_NAME_INFORMATION name_info = NULL;

	status = FltGetFileNameInformation(
		data,
		FLT_FILE_NAME_NORMALIZED |
		FLT_FILE_NAME_QUERY_DEFAULT,
		&name_info
	);
	if (!NT_SUCCESS(status))
		return FLT_PREOP_SUCCESS_NO_CALLBACK;

	status = FltParseFileNameInformation(name_info);
	if (!NT_SUCCESS(status))
	{
		FltReleaseFileNameInformation(name_info);
		return FLT_PREOP_SUCCESS_NO_CALLBACK;
	}

	// PtrToUint(PsGetCurrentProcessId())
	// &name_info->ParentDir
	// &name_info->FinalComponent

	FltReleaseFileNameInformation(name_info);
	return FLT_PREOP_SUCCESS_WITH_CALLBACK;
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

	NTSTATUS status = STATUS_SUCCESS;
	PFLT_FILE_NAME_INFORMATION name_info = NULL;

	status = FltGetFileNameInformation(
		data,
		FLT_FILE_NAME_NORMALIZED |
		FLT_FILE_NAME_QUERY_DEFAULT,
		&name_info
	);
	if (!NT_SUCCESS(status))
		return FLT_POSTOP_FINISHED_PROCESSING;

	status = FltParseFileNameInformation(name_info);
	if (!NT_SUCCESS(status))
	{
		FltReleaseFileNameInformation(name_info);
		return FLT_POSTOP_FINISHED_PROCESSING;
	}

	// PtrToUint(PsGetCurrentProcessId())
	// &name_info->ParentDir
	// &name_info->FinalComponent

	FltReleaseFileNameInformation(name_info);
	return FLT_POSTOP_FINISHED_PROCESSING;
}
