#include "ProcessController.h"


VOID
CreateProcessNotifyRoutine(
	_Inout_		PEPROCESS				process,
	_In_		HANDLE					process_id,
	_Inout_opt_	PPS_CREATE_NOTIFY_INFO	create_info
)
{
	UNREFERENCED_PARAMETER(process);

	if (create_info == NULL)
	{
		AccessControllerRemovePermissionByProcessId(process_id);
		return;
	}

	HANDLE parent_process_id = PsGetCurrentProcessId();
	if (parent_process_id == NULL)
		return;
	UINT32 permission = AccessControllerGetPermissionByProcessId(parent_process_id);

	/* Create Process */
	if (!AccessControllerIsAllowAccess(permission, CREATE_PROCESS))
	{
		create_info->CreationStatus = STATUS_UNSUCCESSFUL;
		
		UNICODE_STRING parent_process_path = GetProcessPathFromProcessId(parent_process_id);
		if (parent_process_path.Buffer == NULL)
			return;
		AgentControllerShowAccessBlockedToast(parent_process_path.Buffer, CREATE_PROCESS);
		RtlFreeUnicodeString(&parent_process_path);
	}
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
