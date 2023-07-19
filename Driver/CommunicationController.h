#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include <fltKernel.h>
#include "ProcessHolder.h"
#include "AccessController.h"
#include "StringUtils.h"
#include "sync.h"


#define MINIFLT_PORT_NAME			L"\\SandcessMinifltPort"
#define MINIFLT_MSG_BUFFER_SIZE		4096


NTSTATUS
CommunicationControllerInitialize(
	_In_ PFLT_FILTER flt_handle
);


#endif // !__COMMUNICATION_CONTROLLER_H__
