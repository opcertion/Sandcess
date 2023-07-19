#include "CommunicationController.h"


typedef struct _USER_TO_FLT
{
	WCHAR buffer[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} USER_TO_FLT, *PUSER_TO_FLT;

typedef struct _FLT_TO_UESR
{
	WCHAR buffer[MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)];
} FLT_TO_USER, *PFLT_TO_USER;


PFLT_PORT g_flt_port = NULL;


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
	SyncFastMutexLock();

	PUSER_TO_FLT req; RtlZeroMemory(&req, sizeof(req));
	PFLT_TO_USER resp; RtlZeroMemory(&resp, sizeof(resp));

	if (input_buffer && input_buffer_size == sizeof(USER_TO_FLT))
	{
		req = (PUSER_TO_FLT)input_buffer;

		if (WstringStartswith(req->buffer, L"SetPermission"))
		{
			const SIZE_T req_buffer_length = wcsnlen(req->buffer, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR));
			UNICODE_STRING path; RtlZeroMemory(&path, sizeof(path));
			UINT32 permission = 0u;

			path.Buffer = WstringSubstr(req->buffer, 14, req_buffer_length - 3);
			if (path.Buffer == NULL)
				goto CLEANUP;

			path.Length = (USHORT)((req_buffer_length - 16) * sizeof(WCHAR));
			path.MaximumLength = path.Length;
			permission = (UINT32)(
				(UINT32)((req->buffer[req_buffer_length - 2]) << 16) |
				(UINT32)(req->buffer[req_buffer_length - 1])
			);
			AccessControllerSetPermission(path, permission);
			ExFreePool(path.Buffer);
		}
	}

	if (output_buffer && output_buffer_size == sizeof(FLT_TO_USER))
	{
		resp = (PFLT_TO_USER)output_buffer;
		wcscpy(resp->buffer, L"0");
		*return_output_buffer_size = sizeof(resp->buffer);
	}
CLEANUP:
	SyncFastMutexUnlock();
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
