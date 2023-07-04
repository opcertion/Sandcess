#include "ProcessController.h"


VOID
CreateProcessNotifyRoutine(
	_In_ HANDLE		parent_id,
	_In_ HANDLE		process_id,
	_In_ BOOLEAN	flag
)
{
	/* Create Process */
	if (flag)
	{
		ProcessHolderAddProcess(process_id);

		KdPrint((
			"[Sandcess] -> [PID: %u] Created (Parent ID: %u).\n",
			PtrToUint(process_id),
			PtrToUint(parent_id)
		));
	}
	/* Delete Process */
	else
	{
		ProcessHolderDeleteProcess(process_id);

		KdPrint((
			"[Sandcess] -> [PID: %u] Deleted(Parent ID: %u).\n",
			PtrToUint(process_id),
			PtrToUint(parent_id)
		));
	}
	KdPrint((
		"[Sandcess] -> Process Count: %u.\n",
		ProcessHolderGetProcessCount()
	));
}


NTSTATUS
ProcessControllerInitialize()
{
	return PsSetCreateProcessNotifyRoutine(
		CreateProcessNotifyRoutine,
		FALSE
	);
}


VOID
ProcessControllerRelease()
{
	PsSetCreateProcessNotifyRoutine(
		CreateProcessNotifyRoutine,
		TRUE
	);
}
