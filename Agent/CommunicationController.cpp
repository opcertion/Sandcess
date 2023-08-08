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


FLT_TO_USER CommunicationController::Send(_In_ PUSER_TO_FLT req)
{
	FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));
	DWORD returned_bytes;

	HRESULT h_result = FilterSendMessage(
		port_handle,
		req,
		sizeof(*req),
		&resp,
		MSG_BUFFER_SIZE,
		&returned_bytes
	);
	if (IS_ERROR(h_result))
		ZeroMemory(&resp, sizeof(resp));
	return resp;
}


HANDLE CommunicationController::GetPortHandle()
{
	return port_handle;
}
