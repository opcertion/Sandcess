#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include <windows.h>
#include <fltUser.h>
#include "ToastController.h"
#include "AccessController.h"


#define MINIFLT_PORT_NAME			L"\\SandcessMinifltPort"
#define MINIFLT_MSG_BUFFER_SIZE		2048


#pragma pack( push, 1 )
typedef struct _USER_TO_FLT
{
	UCHAR type;
	WCHAR buffer1[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
	WCHAR buffer2[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, * PUSER_TO_FLT;
#pragma pack( pop )

#pragma pack( push, 1 )
typedef struct _FLT_TO_UESR
{
	UCHAR type;
	WCHAR buffer1[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
	WCHAR buffer2[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} FLT_TO_USER, * PFLT_TO_USER;
#pragma pack ( pop )

typedef struct _FLT_TO_USER_WITH_HEADER
{
	FILTER_MESSAGE_HEADER header;
	FLT_TO_USER message;
} FLT_TO_USER_WITH_HEADER, *PFLT_TO_USER_WITH_HEADER;


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


class CommunicationController
{
private:
	HANDLE port_handle;

public:
	CommunicationController();
	~CommunicationController();
	
	HRESULT Connect();
	VOID Close();
	FLT_TO_USER Send(_In_ PUSER_TO_FLT req);
	VOID ProcessRequest();
};


#endif // !__COMMUNICATION_CONTROLLER_H__
