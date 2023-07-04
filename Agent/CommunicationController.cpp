#include "CommunicationController.h"


namespace miniflt
{
	CommunicationController::CommunicationController()
	{
		ZeroMemory(&port_handle, sizeof(port_handle));
	}


	CommunicationController::~CommunicationController()
	{
		Close();
		ZeroMemory(&port_handle, sizeof(port_handle));
	}


	HRESULT CommunicationController::Connect()
	{
		return FilterConnectCommunicationPort(
			PORT_NAME,
			0,
			nullptr,
			0,
			nullptr,
			&port_handle
		);
	}


	VOID CommunicationController::Close()
	{
		if (port_handle)
			FilterClose(port_handle);
	}


	USER_TO_FLT_REPLY CommunicationController::Send(const USER_TO_FLT *req)
	{
		USER_TO_FLT_REPLY reply; ZeroMemory(&reply, sizeof(reply));
		DWORD returned_bytes;

		HRESULT h_result = FilterSendMessage(
			port_handle,
			&req,
			sizeof(req),
			&reply,
			sizeof(reply),
			&returned_bytes
		);

		if (IS_ERROR(h_result))
		{
			reply.msg[0] = L'\0';
			return reply;
		}
		if (returned_bytes < MSG_BUFFER_SIZE)
			reply.msg[returned_bytes / sizeof(WCHAR)] = L'\0';
		return reply;
	}
};
