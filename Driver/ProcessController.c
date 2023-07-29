#include "ProcessController.h"


VOID
CreateProcessNotifyRoutine(
	_Inout_		PEPROCESS				process,
	_In_		HANDLE					process_id,
	_Inout_opt_	PPS_CREATE_NOTIFY_INFO	create_info
)
{
	UNREFERENCED_PARAMETER(process);
	UNREFERENCED_PARAMETER(process_id);

	if (create_info == NULL)
	{
		//ProcessHolderDeleteProcess(process_id);
		return;
	}
	//ProcessHolderAddProcess(process_id);

	HANDLE parent_process_id = PsGetCurrentProcessId();
	UNICODE_STRING parent_process_path; RtlZeroMemory(&parent_process_path, sizeof(parent_process_path));

	parent_process_path = GetProcessPathFromProcessId(parent_process_id);
	if (parent_process_path.Buffer == NULL)
		return;
	UINT32 permission = AccessControllerGetPermission(parent_process_path);

	if (!AccessControllerIsAllowAccess(permission, CREATE_PROCESS))
	{
		create_info->CreationStatus = STATUS_UNSUCCESSFUL;
	}

	RtlFreeUnicodeString(&parent_process_path);
}


NTSTATUS
ProcessControllerInitialize()
{
	return PsSetCreateProcessNotifyRoutineEx(
		CreateProcessNotifyRoutine,
		FALSE
	);
}


VOID
ProcessControllerRelease()
{
	PsSetCreateProcessNotifyRoutineEx(
		CreateProcessNotifyRoutine,
		TRUE
	);
}
