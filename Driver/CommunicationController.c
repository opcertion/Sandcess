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

		switch (req->type)
		{
		case SET_PERMISSION:
		{
			if (wcsnlen(req->buffer2, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)) != 2)
				goto CLEANUP;

			UNICODE_STRING path; RtlInitUnicodeString(&path, req->buffer1);
			UINT32 permission = (((UINT32)(req->buffer2[0]) << 16) | (UINT32)(req->buffer2[1]));
			if (!AccessControllerSetPermissionByPath(&path, permission))
				goto CLEANUP;
			break;
		}
		case CREATE_CONTAINER:
		case DELETE_CONTAINER:
		case ADD_TARGET_PATH:
		case DELETE_TARGET_PATH:
		case ADD_ACCESSIBLE_PATH:
		case DELETE_ACCESSIBLE_PATH:
		{
			UNICODE_STRING buffer1; RtlInitUnicodeString(&buffer1, req->buffer1);
			ULONG temp_container_id = 0;
			RtlUnicodeStringToInteger(&buffer1, 10, &temp_container_id);
			if (!IS_VALID_CONTAINER_ID(temp_container_id))
				goto CLEANUP;
			CHAR container_id = (CHAR)temp_container_id;
			
			switch (req->type)
			{
			case CREATE_CONTAINER:
			{
				if (!ContainerControllerCreateContainer(container_id))
					goto CLEANUP;
				break;
			}
			case DELETE_CONTAINER:
			{
				if (!ContainerControllerDeleteContainer(container_id))
					goto CLEANUP;
				break;
			}
			case ADD_TARGET_PATH:
			{
				UNICODE_STRING path; RtlInitUnicodeString(&path, req->buffer2);
				if (!ContainerControllerAddTargetPath(container_id, &path))
					goto CLEANUP;
				break;
			}
			case DELETE_TARGET_PATH:
			{
				UNICODE_STRING path; RtlInitUnicodeString(&path, req->buffer2);
				if (!ContainerControllerDeleteTargetPath(container_id, &path))
					goto CLEANUP;
				break;
			}
			case ADD_ACCESSIBLE_PATH:
			{
				UNICODE_STRING path; RtlInitUnicodeString(&path, req->buffer2);
				if (!ContainerControllerAddAccessiblePath(container_id, &path))
					goto CLEANUP;
				break;
			}
			case DELETE_ACCESSIBLE_PATH:
			{
				UNICODE_STRING path; RtlInitUnicodeString(&path, req->buffer2);
				if (!ContainerControllerDeleteAccessiblePath(container_id, &path))
					goto CLEANUP;
				break;
			}
			default:
				goto CLEANUP;
			}
			break;
		}
		default:
			goto CLEANUP;
		}
	}

	if (output_buffer != NULL && output_buffer_size == sizeof(FLT_TO_USER))
	{
		resp = (PFLT_TO_USER)output_buffer;
		resp->type = req->type;
		*return_output_buffer_size = sizeof(FLT_TO_USER);
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
