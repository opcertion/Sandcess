#include "ProcessHolder.h"


/* Extern */ PPROCESS_HOLDER g_process_holder = NULL;


BOOLEAN
ProcessHolderAddProcess(
	_In_ HANDLE process_id
)
{
	BOOLEAN ret = TRUE;
	SyncFastMutexLock();

	if (g_process_holder == NULL)
	{
		g_process_holder = (PPROCESS_HOLDER)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(PROCESS_HOLDER), 'PH');
		if (g_process_holder == NULL)
		{
			KdPrint(("[Sandcess] -> [ProcessHolder_ProcessHolderAddProcess] ExAllocatePool2 return null."));
			ret = FALSE;
			goto CLEANUP;
		}
		g_process_holder->process_id = NULL;
		g_process_holder->next_node = NULL;
	}

	if (g_process_holder->process_id == NULL)
	{
		g_process_holder->process_id = process_id;
		g_process_holder->next_node = NULL;
		goto CLEANUP;
	}
	PPROCESS_HOLDER target_node = NULL;

	target_node = (PPROCESS_HOLDER)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(PROCESS_HOLDER), 'PH');
	if (target_node == NULL)
	{
		KdPrint(("[Sandcess] -> [ProcessHolder_ProcessHolderAddProcess] ExAllocatePool2 return null."));
		ret = FALSE;
		goto CLEANUP;
	}

	target_node->process_id = process_id;
	target_node->next_node = g_process_holder;
	g_process_holder = target_node;

CLEANUP:
	SyncFastMutexUnlock();
	return ret;
}


VOID
ProcessHolderDeleteProcess(
	_In_ HANDLE process_id
)
{
	SyncFastMutexLock();

	if (g_process_holder == NULL || g_process_holder->process_id == NULL || process_id == NULL)
		goto CLEANUP;

	CONST UINT32 target_pid = PtrToUint(process_id);
	if (PtrToUint(g_process_holder->process_id) == target_pid)
	{
		if (g_process_holder->next_node == NULL)
		{
			g_process_holder->process_id = NULL;
			goto CLEANUP;
		}
		g_process_holder = g_process_holder->next_node;
		goto CLEANUP;
	}
	PPROCESS_HOLDER trace_node = g_process_holder;
	PPROCESS_HOLDER prev_node = NULL;

	do
	{
		if (trace_node->next_node == NULL)
			goto CLEANUP;
		prev_node = trace_node;
		trace_node = trace_node->next_node;
	} while (
		trace_node->process_id != NULL &&
		PtrToUint(trace_node->process_id) != target_pid
	);

	ExFreePool(prev_node->next_node);
	prev_node->next_node = trace_node->next_node;

CLEANUP:
	SyncFastMutexUnlock();
	return;
}


UINT32
ProcessHolderGetProcessCount()
{
	SyncFastMutexLock();

	UINT32 ret = 0;
	if (g_process_holder == NULL)
		goto CLEANUP;
	PPROCESS_HOLDER trace_node = g_process_holder;

	for (; trace_node->process_id != NULL; ret++)
	{
		if (trace_node->next_node == NULL)
			break;
		trace_node = trace_node->next_node;
	}

CLEANUP:
	SyncFastMutexUnlock();
	return ret;
}


VOID
ProcessHolderRelease()
{
	SyncFastMutexLock();

	if (g_process_holder == NULL)
		goto CLEANUP;

	PPROCESS_HOLDER trace_node = g_process_holder;
	PPROCESS_HOLDER prev_node = NULL;

	while (&trace_node != NULL)
	{
		prev_node = trace_node;
		if (trace_node->next_node == NULL)
			break;
		trace_node = trace_node->next_node;
		ExFreePool(prev_node);
	}

CLEANUP:
	SyncFastMutexUnlock();
	return;
}
