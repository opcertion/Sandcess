#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include <windows.h>
#include <fltUser.h>


#define PORT_NAME			L"\\SandcessMinifltPort"
#define MSG_BUFFER_SIZE		4096


typedef struct _USER_TO_FLT
{
	WCHAR buffer[MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, *PUSER_TO_FLT;

typedef struct _FLT_TO_USER
{
	WCHAR buffer[MSG_BUFFER_SIZE / sizeof(WCHAR)];
} FLT_TO_USER, *PFLT_TO_USER;

typedef struct _FLT_TO_USER_WITH_HEADER
{
	FILTER_MESSAGE_HEADER header;
	FLT_TO_USER message;
} FLT_TO_USER_WITH_HEADER, *PFLT_TO_USER_WITH_HEADER;


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
	HANDLE GetPortHandle();
};


#endif // !__COMMUNICATION_CONTROLLER_H__
