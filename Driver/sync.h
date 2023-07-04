#ifndef __SYNC_H__
#define __SYNC_H__


#include <ntddk.h>


extern VOID SyncMutexInitialize();
extern VOID SyncFastMutexLock();
extern VOID SyncFastMutexUnlock();


#endif // !__SYNC_H__
