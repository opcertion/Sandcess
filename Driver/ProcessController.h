#ifndef __PROCESS_CONTROLLER_H__
#define __PROCESS_CONTROLLER_H__


#include "AccessController.h"
#include "ProcessUtils.h"
#include "StringUtils.h"


NTSTATUS
ProcessControllerInitialize();

VOID
ProcessControllerRelease();


#endif // !__PROCESS_CONTROLLER_H__
