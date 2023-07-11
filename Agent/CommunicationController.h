#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include <windows.h>
#include <fltUser.h>


namespace miniflt
{
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

	class CommunicationController
	{
	private:
		HANDLE port_handle;

	public:
		CommunicationController();
		~CommunicationController();
		
		HRESULT Connect();
		VOID Close();
		FLT_TO_USER Send(_In_ USER_TO_FLT *req);
	};
};


#endif // !__COMMUNICATION_CONTROLLER_H__
