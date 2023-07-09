#include "CommunicationController.h"


typedef struct _USER_TO_FLT
{
	WCHAR msg[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, *PUSER_TO_FLT;

typedef struct _USER_TO_FLT_REPLY
{
	WCHAR msg[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT_REPLY, *PUSER_TO_FLT_REPLY;


PFLT_PORT g_flt_port;


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
	UNREFERENCED_PARAMETER(client_port);
	UNREFERENCED_PARAMETER(server_cookie);
	UNREFERENCED_PARAMETER(connection_context);
	UNREFERENCED_PARAMETER(connection_context_size);
	UNREFERENCED_PARAMETER(connection_port_cookie);

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
MinifltPortMessageRoutine(
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
	if (input_buffer && input_buffer_size == sizeof(USER_TO_FLT))
	{
		req = (PUSER_TO_FLT)input_buffer;
	}

	if (output_buffer && output_buffer_size == sizeof(USER_TO_FLT_REPLY))
	{
		PUSER_TO_FLT_REPLY reply = (PUSER_TO_FLT_REPLY)output_buffer;
		wcscpy(reply->msg, L"");
		*return_output_buffer_size = (ULONG)(wcslen(reply->msg) * sizeof(WCHAR));
	}
	return STATUS_SUCCESS;
}
#pragma warning( pop )


NTSTATUS
CommunicationControllerInitialize(
	_In_ PFLT_FILTER flt_handle
)
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
		flt_handle,
		&g_flt_port,
		&object_attributes,
		NULL,
		MinifltPortConnectRoutine,
		MinifltPortDisconnectRoutine,
		MinifltPortMessageRoutine,
		1
	);
	return status;
}
