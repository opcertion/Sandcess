#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include "MinifltController.h"
#include "AccessController.h"
#include "StringUtils.h"
#include "sync.h"


#define MINIFLT_PORT_NAME			L"\\SandcessMinifltPort"
#define MINIFLT_MSG_BUFFER_SIZE		4096


typedef struct _USER_TO_FLT
{
	WCHAR buffer[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, *PUSER_TO_FLT;

typedef struct _FLT_TO_UESR
{
	WCHAR buffer[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} FLT_TO_USER, *PFLT_TO_USER;



NTSTATUS
CommunicationControllerInitialize();


VOID
CommunicationControllerSendMessageToAgent(
	_In_ PFLT_TO_USER message
);


#endif // !__COMMUNICATION_CONTROLLER_H__
