#ifndef __COMMUNICATION_CONTROLLER_H__
#define __COMMUNICATION_CONTROLLER_H__


#include <windows.h>
#include <fltUser.h>


namespace miniflt
{
#define PORT_NAME			L"\\SandcessMinifltPort"
#define MSG_BUFFER_SIZE		2048

	typedef struct _USER_TO_FLT
	{
		WCHAR msg[MSG_BUFFER_SIZE / sizeof(WCHAR)];
	} USER_TO_FLT, *PUSER_TO_FLT;

	typedef struct _USER_TO_FLT_REPLY
	{
		WCHAR msg[MSG_BUFFER_SIZE / sizeof(WCHAR)];
	} USER_TO_FLT_REPLY, *PUSER_TO_FLT_REPLY;

	class CommunicationController
	{
	private:
		HANDLE port_handle;

	public:
		CommunicationController();
		~CommunicationController();
		
		HRESULT Connect();
		VOID Close();
		USER_TO_FLT_REPLY Send(const USER_TO_FLT *req);
	};
};


#endif // !__COMMUNICATION_CONTROLLER_H__
