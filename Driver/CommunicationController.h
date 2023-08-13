#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include "MinifltController.h"
#include "AccessController.h"
#include "StringUtils.h"


#define MINIFLT_PORT_NAME			L"\\SandcessMinifltPort"
#define MINIFLT_MSG_BUFFER_SIZE		2048


#pragma pack( push, 1 )
typedef struct _USER_TO_FLT
{
	UCHAR type;
	WCHAR buffer1[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
	WCHAR buffer2[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, *PUSER_TO_FLT;
#pragma pack( pop )

#pragma pack( push, 1 )
typedef struct _FLT_TO_UESR
{
	UCHAR type;
	WCHAR buffer1[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
	WCHAR buffer2[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} FLT_TO_USER, *PFLT_TO_USER;
#pragma pack ( pop )


typedef enum _USER_TO_FLT_MESSAGE_TYPE
{
	__USER_TO_FLT_MESSAGE_TYPE_RESERVED1 = 0,
	SET_PERMISSION,
} USER_TO_FLT_MESSAGE_TYPE;


typedef enum _FLT_TO_USER_MESSAGE_TYPE
{
	__FLT_TO_USER_MESSAGE_TYPE_RESERVED1 = 0,
	SHOW_ACCESS_BLOCKED_TOAST,
} FLT_TO_USER_MESSAGE_TYPE;


NTSTATUS
CommunicationControllerInitialize();


VOID
CommunicationControllerSendMessageToAgent(
	_In_ PFLT_TO_USER message
);


#endif // !__COMMUNICATION_CONTROLLER_H__
