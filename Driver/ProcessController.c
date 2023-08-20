#include "ProcessController.h"


#define NOTIFY_ROUTINE_BLOCK_ACCESS(_access_type_) \
do \
{ \
	create_info->CreationStatus = STATUS_UNSUCCESSFUL; \
	AgentControllerShowAccessBlockedToast(PsGetCurrentProcessId(), _access_type_); \
} while (0);


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

	if (!ContainerControllerIsAllowAccessProcessIdToProcessId(parent_process_id, process_id))
	{
		NOTIFY_ROUTINE_BLOCK_ACCESS(CREATE_PROCESS);
	}

	UINT32 permission = AccessControllerGetPermissionByProcessId(parent_process_id);

	/* Create Process */
	if (!IS_ALLOW_ACCESS(permission, CREATE_PROCESS))
	{
		NOTIFY_ROUTINE_BLOCK_ACCESS(CREATE_PROCESS);
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
