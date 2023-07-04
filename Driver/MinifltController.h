#ifndef __MINIFLT_CONTROLLER_H__
#define __MINIFLT_CONTROLLER_H__


#include <fltKernel.h>
#include "FileSystemController.h"


extern PFLT_FILTER g_flt_handle; // MinifltController.c


NTSTATUS
MinifltControllerInitialize(
	_In_ PDRIVER_OBJECT driver_object
);


#endif // !__MINIFLT_CONTROLLER_H__
