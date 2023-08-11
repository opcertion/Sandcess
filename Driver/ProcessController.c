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

		WCHAR toast_message[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)] = { 0 };
		USHORT backslash_idx = parent_process_path.Length - 1;
		for (; backslash_idx > 0 && parent_process_path.Buffer[backslash_idx] != L'\\'; backslash_idx--) { }
		backslash_idx += 1;
		for (USHORT idx = backslash_idx; idx < parent_process_path.Length; idx++)
			toast_message[idx - backslash_idx] = parent_process_path.Buffer[idx];

		if (parent_process_path.Length - backslash_idx < MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR) - 48)
		{
			wcscpy(
				&toast_message[wcslen(toast_message)],
				L" access to the Create Process has been blocked."
			);
			AgentControllerShowAccessBlockedToast(toast_message);
		}
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
