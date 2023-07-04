#ifndef __PROCESS_CONTROLLER_H__
#define __PROCESS_CONTROLLER_H__

#include "ProcessHolder.h"


NTSTATUS
ProcessControllerInitialize();

VOID
ProcessControllerRelease();


#endif // !__PROCESS_CONTROLLER_H__
