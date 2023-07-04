#include "sync.h"


FAST_MUTEX g_fast_mutex;


__forceinline VOID SyncMutexInitialize()
{
	ExInitializeFastMutex(&g_fast_mutex);
}


__inline VOID SyncFastMutexLock()
{
	ASSERT(KeGetCurrentIrql() <= APC_LEVEL);
	ExAcquireFastMutex(&g_fast_mutex);
}


__inline VOID SyncFastMutexUnlock()
{
	ExReleaseFastMutex(&g_fast_mutex);
}

