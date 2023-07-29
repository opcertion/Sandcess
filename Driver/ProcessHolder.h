#ifndef __PROCESS_HOLDER_H__
#define __PROCESS_HOLDER_H__


#include <fltKernel.h>
#include "sync.h"


#pragma pack( push, 1 )
typedef struct _PROCESS_HOLDER
{
	HANDLE process_id;
	struct _PROCESS_HOLDER* next_node;
} PROCESS_HOLDER, *PPROCESS_HOLDER;
#pragma pack( pop )


extern PPROCESS_HOLDER g_process_holder; // ProcessHolder.c


BOOLEAN
ProcessHolderAddProcess(
	_In_ HANDLE process_id
);

VOID
ProcessHolderDeleteProcess(
	_In_ HANDLE process_id
);

UINT32
ProcessHolderGetProcessCount();

VOID
ProcessHolderRelease();


#endif // !__PROCESS_HOLDER_H__
