#include "CommunicationController.h"


PFLT_PORT g_flt_port = NULL;
PFLT_PORT g_agent_port = NULL;


#pragma warning( push )
#pragma warning( disable:6101 )
NTSTATUS
MinifltPortConnectRoutine(
	_In_	PFLT_PORT	client_port,
	_In_	PVOID		server_cookie,
	_In_	PVOID		connection_context,
	_In_	ULONG		connection_context_size,
	_Out_	PVOID*		connection_port_cookie
)
{
	UNREFERENCED_PARAMETER(server_cookie);
	UNREFERENCED_PARAMETER(connection_context);
	UNREFERENCED_PARAMETER(connection_context_size);
	UNREFERENCED_PARAMETER(connection_port_cookie);

	if (g_agent_port == NULL)
		g_agent_port = client_port;

	return STATUS_SUCCESS;
}
#pragma warning( pop )


VOID
MinifltPortDisconnectRoutine(
	_In_ PVOID connection_cookie
)
{
	UNREFERENCED_PARAMETER(connection_cookie);
}


#pragma warning( push )
#pragma warning( disable:6101 )
NTSTATUS
MinifltPortCommunicationRoutine(
	_In_		PVOID	port_cookie,
	_In_opt_	PVOID	input_buffer,
	_In_		ULONG	input_buffer_size,
	_Out_opt_	PVOID	output_buffer,
	_In_		ULONG	output_buffer_size,
	_Out_		PULONG	return_output_buffer_size
)
{
	UNREFERENCED_PARAMETER(port_cookie);

	PUSER_TO_FLT req; RtlZeroMemory(&req, sizeof(req));
	PFLT_TO_USER resp; RtlZeroMemory(&resp, sizeof(resp));

	if (input_buffer != NULL && input_buffer_size == sizeof(USER_TO_FLT))
	{
		req = (PUSER_TO_FLT)input_buffer;

		if (WideStringStartswith(req->buffer, L"SetPermission"))
		{
			SIZE_T req_buffer_length = wcsnlen(req->buffer, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR));
			if (req_buffer_length <= 18)
				goto CLEANUP;
			
			UNICODE_STRING path; RtlZeroMemory(&path, sizeof(path));
			UINT32 permission = 0u;

			path.Buffer = WideStringSubstr(req->buffer, 14, req_buffer_length - 3);
			if (path.Buffer == NULL)
				goto CLEANUP;

			path.Length = (USHORT)(req_buffer_length - 17) * sizeof(WCHAR);
			path.MaximumLength = path.Length;
			permission = (UINT32)(
				(UINT32)((req->buffer[req_buffer_length - 2]) << 16) |
				(UINT32)(req->buffer[req_buffer_length - 1])
			);
			AccessControllerSetPermissionByPath(path, permission);
			RtlFreeUnicodeString(&path);
		}
	}

	if (output_buffer != NULL && output_buffer_size == sizeof(FLT_TO_USER))
	{
		resp = (PFLT_TO_USER)output_buffer;
		wcscpy(resp->buffer, L"0");
		*return_output_buffer_size = sizeof(resp->buffer);
	}
CLEANUP:
	return STATUS_SUCCESS;
}
#pragma warning( pop )


NTSTATUS
CommunicationControllerInitialize()
{
	NTSTATUS status = STATUS_SUCCESS;
	UNICODE_STRING port_name = RTL_CONSTANT_STRING(MINIFLT_PORT_NAME);
	PSECURITY_DESCRIPTOR security_descriptor; RtlZeroMemory(&security_descriptor, sizeof(security_descriptor));
	OBJECT_ATTRIBUTES object_attributes; RtlZeroMemory(&object_attributes, sizeof(object_attributes));

	status = FltBuildDefaultSecurityDescriptor(
		&security_descriptor,
		FLT_PORT_ALL_ACCESS
	);
	if (!NT_SUCCESS(status))
		return status;
	
	InitializeObjectAttributes(
		&object_attributes,
		&port_name,
		OBJ_KERNEL_HANDLE | OBJ_CASE_INSENSITIVE,
		NULL,
		security_descriptor
	);

	status = FltCreateCommunicationPort(
		g_flt_handle,
		&g_flt_port,
		&object_attributes,
		NULL,
		MinifltPortConnectRoutine,
		MinifltPortDisconnectRoutine,
		MinifltPortCommunicationRoutine,
		2
	);
	return status;
}


VOID
CommunicationControllerSendMessageToAgent(
	_In_ PFLT_TO_USER message
)
{
	if (g_agent_port == NULL)
		return;

	LARGE_INTEGER timeout; RtlZeroMemory(&timeout, sizeof(timeout));
	timeout.QuadPart = 0;

	FltSendMessage(
		g_flt_handle,
		&g_agent_port,
		message,
		sizeof(FLT_TO_USER),
		NULL,
		NULL,
		&timeout
	);
}
