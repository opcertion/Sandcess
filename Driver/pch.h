#ifndef __PCH_H__
#define __PCH_H__


#include "AccessController.h"
#include "ContainerController.h"
#include "MinifltController.h"
#include "FileSystemController.h"
#include "CommunicationController.h"
#include "ProcessController.h"


#define CHECK_ERROR(_func_name_, _ntstatus_, _to_) \
do { \
	if (!NT_SUCCESS(_ntstatus_)) \
	{ \
		KdPrint(("[Sandcess] -> [" #_func_name_ "] failed (status: 0x%x).", _ntstatus_)); \
		goto _to_; \
	} \
} while(0);


#endif // !__PCH_H__
