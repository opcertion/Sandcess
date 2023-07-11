#ifndef __PROCESS_HOLDER_H__
#define __PROCESS_HOLDER_H__


#include <ntddk.h>
#include "sync.h"


#pragma pack( push, 1 )
typedef struct _PROCESS_HOLDER_NODE
{
	HANDLE process_id;
	struct _PROCESS_HOLDER_NODE* next_node;
} PROCESS_HOLDER_NODE;
#pragma pack( pop )


extern PROCESS_HOLDER_NODE* g_process_holder; // ProcessHolder.c


BOOLEAN
ProcessHolderAddProcess(
	_In_ const HANDLE process_id
);

VOID
ProcessHolderDeleteProcess(
	_In_ const HANDLE process_id
);

UINT32
ProcessHolderGetProcessCount();

VOID
ProcessHolderRelease();


#endif // !__PROCESS_HOLDER_H__
