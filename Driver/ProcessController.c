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
		AgentControllerShowAccessBlockedToast(parent_process_id, CREATE_PROCESS);
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
