#include "AccessController.h"


#define ACCESS_INFO_NEXT_NODES_LENGTH			256
#define PROCESS_ACCESS_INFO_NEXT_NODES_LENGTH	5


/* based on trie */
#pragma pack( push, 1 )
typedef struct _ACCESS_INFO
{
	CHAR ch;
	UINT32 permission;
	struct _ACCESS_INFO* next_nodes[ACCESS_INFO_NEXT_NODES_LENGTH];
} ACCESS_INFO, *PACCESS_INFO;
#pragma pack( pop )


#pragma pack( push, 1 )
typedef struct _PROCESS_ACCESS_INFO
{
	UINT32 permission;
	struct _PROCESS_ACCESS_INFO* next_nodes[PROCESS_ACCESS_INFO_NEXT_NODES_LENGTH];
} PROCESS_ACCESS_INFO, *PPROCESS_ACCESS_INFO;
#pragma pack( pop )


PACCESS_INFO g_access_info = NULL;
PPROCESS_ACCESS_INFO g_process_access_info = NULL;
FILE g_access_info_file;


BOOLEAN
AccessControllerSetPermissionByPath(
	_In_ UNICODE_STRING path,
	_In_ UINT32			permission
)
{
	UnicodeStringNormalize(&path);

	PACCESS_INFO trace_node = g_access_info;
	BOOLEAN ret = TRUE;

	for (USHORT idx = 8; idx < path.Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)((path.Buffer[idx] & 0xff00) >> 8);
		UCHAR ch2 = (UCHAR)(path.Buffer[idx] & 0x00ff);

		if (trace_node->next_nodes[ch1] == NULL)
		{
			trace_node->next_nodes[ch1] = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
			if (trace_node->next_nodes[ch1] == NULL)
			{
				KdPrint(("[Sandcess] -> [AccessController_AccessControllerSetPermissionByPath] ExAllocatePool2 return null."));
				ret = FALSE;
				goto CLEANUP;
			}
		}
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
		{
			trace_node->next_nodes[ch2] = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
			if (trace_node->next_nodes[ch2] == NULL)
			{
				KdPrint(("[Sandcess] -> [AccessController_AccessControllerSetPermissionByPath] ExAllocatePool2 return null."));
				ret = FALSE;
				goto CLEANUP;
			}
		}
		trace_node = trace_node->next_nodes[ch2];
	}
	trace_node->permission = permission;

CLEANUP:
	return ret;
}


UINT32
AccessControllerGetPermissionByPath(
	_In_ UNICODE_STRING path
)
{
	UnicodeStringNormalize(&path);

	PACCESS_INFO trace_node = g_access_info;
	trace_node->permission = (UINT32)0xffffffff;
	UINT32 ret = 0u;

	for (USHORT idx = 8; idx < path.Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)((path.Buffer[idx] & 0xff00) >> 8);
		UCHAR ch2 = (UCHAR)(path.Buffer[idx] & 0x00ff);

		if (trace_node->next_nodes[ch1] == NULL)
		{
			ret = (UINT32)0xffffffff;
			goto CLEANUP;
		}
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
		{
			ret = (UINT32)0xffffffff;
			goto CLEANUP;
		}
		trace_node = trace_node->next_nodes[ch2];
	}
	ret = trace_node->permission;

CLEANUP:
	return ret;
}



BOOLEAN
AccessControllerSetPermissionByProcessId(
	_In_ HANDLE			process_id,
	_In_ UINT32			permission
)
{
	BOOLEAN ret = TRUE;

	UINT32 pid = PtrToUint(process_id);
	PPROCESS_ACCESS_INFO trace_node = g_process_access_info;
	while (pid != 0)
	{
		SIZE_T node_idx = (pid % 10) >> 1;
		trace_node = trace_node->next_nodes[node_idx];

		if (trace_node == NULL)
		{
			trace_node = (PPROCESS_ACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(PROCESS_ACCESS_INFO), 'AC');
			if (trace_node == NULL)
			{
				KdPrint(("[Sandcess] -> [AccessController_AccessControllerSetPermissionByProcessId] ExAllocatePool2 return null."));
				ret = FALSE;
				goto CLEANUP;
			}
		}
		pid /= 10;
	}

	HANDLE parent_process_id = PsGetCurrentProcessId();
	if (parent_process_id == NULL || PtrToUint(parent_process_id) == PtrToUint(process_id))
	{
		trace_node->permission = permission;
		goto CLEANUP;
	}
	
	UNICODE_STRING parent_process_path; RtlZeroMemory(&parent_process_path, sizeof(parent_process_path));
	parent_process_path = GetProcessPathFromProcessId(parent_process_id);
	if (parent_process_path.Buffer == NULL)
	{
		trace_node->permission = permission;
		goto CLEANUP;
	}
	trace_node->permission = (AccessControllerGetPermissionByPath(parent_process_path) & permission);

CLEANUP:
	return ret;
}


UINT32
AccessControllerGetPermissionByProcessId(
	_In_ HANDLE			process_id
)
{
	UINT32 ret = 0u;
	
	UINT32 pid = PtrToUint(process_id);
	PPROCESS_ACCESS_INFO trace_node = g_process_access_info;
	while (pid != 0)
	{
		SIZE_T node_idx = (pid % 10) >> 1;
		if (trace_node->next_nodes[node_idx] == NULL)
		{
			UNICODE_STRING process_path; RtlZeroMemory(&process_path, sizeof(process_path));
			process_path = GetProcessPathFromProcessId(process_id);
			if (process_path.Buffer == NULL)
			{
				ret = (UINT32)0xffffffff;
				goto CLEANUP;
			}
			ret = AccessControllerGetPermissionByPath(process_path);
			RtlFreeUnicodeString(&process_path);
			AccessControllerSetPermissionByProcessId(process_id, ret);
			goto CLEANUP;
		}
		trace_node = trace_node->next_nodes[node_idx];
		pid /= 10;
	}
	ret = trace_node->permission;

CLEANUP:
	return ret;
}


VOID
AccessControllerRemovePermissionByProcessId(
	_In_ HANDLE			process_id
)
{
	UINT32 pid = PtrToUint(process_id);
	PPROCESS_ACCESS_INFO trace_node = g_process_access_info;

	while (1)
	{
		SIZE_T node_idx = (pid % 10) >> 1;
		trace_node = trace_node->next_nodes[node_idx];

		if (trace_node == NULL)
			return;
		pid /= 10;
		if (pid == 0)
		{
			if (trace_node != NULL)
			{
				ExFreePool(trace_node);
				trace_node = NULL;
			}
			return;
		}
	}
}


BOOLEAN
AccessControllerIsAllowAccess(
	_In_ UINT32			permission,
	_In_ ACCESS_TYPE	access_type
)
{
	return (BOOLEAN)((permission >> access_type) & 1);
}


NTSTATUS
AccessControllerInitialize()
{
	RtlZeroMemory(&g_access_info_file, sizeof(g_access_info_file));
	UNICODE_STRING access_info_file_path = RTL_CONSTANT_STRING(L"\\??\\C:\\Sandcess\\ACCESS_INFO.DAT");

	g_access_info_file = OpenFile(access_info_file_path);
	if (!NT_SUCCESS(g_access_info_file.status))
		g_access_info_file = CreateFile(access_info_file_path);

	g_access_info = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
	if (g_access_info == NULL)
	{
		KdPrint(("[Sandcess] -> [AccessController_AccessControllerInitialize] ExAllocatePool2 return null."));
		return STATUS_UNSUCCESSFUL;
	}

	g_process_access_info = (PPROCESS_ACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(PROCESS_ACCESS_INFO), 'AC');
	if (g_process_access_info == NULL)
	{
		KdPrint(("[Sandcess] -> [AccessController_AccessControllerInitialize] ExAllocatePool2 return null."));
		return STATUS_UNSUCCESSFUL;
	}

	return g_access_info_file.status;
}


VOID
AccessControllerRelease()
{
	if (g_access_info_file.handle)
		ZwClose(g_access_info_file.handle);
}
