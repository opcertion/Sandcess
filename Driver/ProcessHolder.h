#ifndef __PROCESS_HOLDER_H__
#define __PROCESS_HOLDER_H__


#include <ntddk.h>
#include "sync.h"


typedef struct _PROCESS_HOLDER_NODE
{
	HANDLE process_id;
	struct _PROCESS_HOLDER_NODE* next_node;
} PROCESS_HOLDER_NODE;


extern PROCESS_HOLDER_NODE* g_process_holder; // ProcessHolder.c


BOOLEAN ProcessHolderAddProcess(const HANDLE process_id);
VOID ProcessHolderDeleteProcess(const HANDLE process_id);
UINT32 ProcessHolderGetProcessCount();
VOID ProcessHolderRelease();


#endif // !__PROCESS_HOLDER_H__
