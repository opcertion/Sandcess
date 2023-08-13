#include "CommunicationController.h"


CommunicationController::CommunicationController()
{
	ZeroMemory(&port_handle, sizeof(port_handle));
}


CommunicationController::~CommunicationController()
{
	Close();
}


HRESULT CommunicationController::Connect()
{
	return FilterConnectCommunicationPort(
		MINIFLT_PORT_NAME,
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


FLT_TO_USER CommunicationController::Send(_In_ PUSER_TO_FLT req)
{
	FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));
	DWORD returned_bytes;

	HRESULT h_result = FilterSendMessage(
		port_handle,
		req,
		sizeof(*req),
		&resp,
		sizeof(resp),
		&returned_bytes
	);
	if (IS_ERROR(h_result))
		ZeroMemory(&resp, sizeof(resp));
	return resp;
}


VOID CommunicationController::ProcessRequest()
{
	static ToastController toast_controller;
	HRESULT h_result;

	try
	{
		FLT_TO_USER_WITH_HEADER resp; ZeroMemory(&resp, sizeof(resp));
		h_result = FilterGetMessage(
			port_handle,
			&resp.header,
			sizeof(resp),
			nullptr
		);
		if (IS_ERROR(h_result))
			return;
		if (resp.message.type == SHOW_ACCESS_BLOCKED_TOAST)
		{
			std::wstring content = L"";
			std::wstring path(resp.message.buffer1);
			UINT access_type = resp.message.buffer2[0];

			path = path.substr(path.rfind(L"\\") + 1);
			switch (access_type)
			{
			case CREATE_PROCESS:
				content = path + L" access to the Create Process has been blocked.";
				break;
			}
			toast_controller.ShowAccessBlockedToast(content);
		}
	}
	catch (...) {}
}
