#ifndef __FILE_SYSTEM_CONTROLLER_H__
#define __FILE_SYSTEM_CONTROLLER_H__


#include <fltKernel.h>
#include "AccessController.h"


NTSTATUS
FileSystemControllerInitialize(
	_In_ PFLT_FILTER flt_handle
);

FLT_PREOP_CALLBACK_STATUS
MinifltCreatePreRoutine(
	_Inout_	PFLT_CALLBACK_DATA		data,
	_In_	PCFLT_RELATED_OBJECTS	flt_object,
	_Out_	PVOID* completion_context
);

FLT_POSTOP_CALLBACK_STATUS
MinifltCreatePostRoutine(
	_Inout_		PFLT_CALLBACK_DATA			data,
	_In_		PCFLT_RELATED_OBJECTS		flt_object,
	_In_opt_	PVOID						completion_context,
	_In_		FLT_POST_OPERATION_FLAGS	flags
);


#endif // !__FILE_SYSTEM_CONTROLLER_H__
