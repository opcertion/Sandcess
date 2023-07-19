#include "AccessController.h"


#define ACCESS_INFO_NEXT_NODES_LENGTH 256


/* based on trie */
#pragma pack( push, 1 )
typedef struct _ACCESS_INFO
{
	CHAR ch;
	UINT32 permission;
	struct _ACCESS_INFO* next_nodes[ACCESS_INFO_NEXT_NODES_LENGTH];
} ACCESS_INFO, *PACCESS_INFO;
#pragma pack( pop )

PACCESS_INFO g_access_info = NULL;
FILE g_access_info_file;


BOOLEAN
AccessControllerSetPermission(
	_In_ UNICODE_STRING path,
	_In_ UINT32			permission
)
{
	PACCESS_INFO trace_node = g_access_info;

	for (USHORT idx = 0; idx < path.Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)((path.Buffer[idx] & 0xff00) >> 8);
		UCHAR ch2 = (UCHAR)(path.Buffer[idx] & 0x00ff);
		
		if (trace_node->next_nodes[ch1] == NULL)
		{
			trace_node->next_nodes[ch1] = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
			if (trace_node->next_nodes[ch1] == NULL)
			{
				KdPrint(("[Sandcess] -> [AccessController_AccessControllerSetPermission] ExAllocatePool2 return null."));
				return FALSE;
			}
		}
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
		{
			trace_node->next_nodes[ch2] = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
			if (trace_node->next_nodes[ch2] == NULL)
			{
				KdPrint(("[Sandcess] -> [AccessController_AccessControllerSetPermission] ExAllocatePool2 return null."));
				return FALSE;
			}
		}
		trace_node = trace_node->next_nodes[ch2];
	}
	trace_node->permission = permission;
	return TRUE;
}


UINT32
AccessControllerGetPermission(
	_In_ UNICODE_STRING path
)
{
	PACCESS_INFO trace_node = g_access_info;

	for (USHORT idx = 0; idx < path.Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)((path.Buffer[idx] & 0xff00) >> 8);
		UCHAR ch2 = (UCHAR)(path.Buffer[idx] & 0x00ff);

		if (trace_node->next_nodes[ch1] == NULL)
			return 0u;
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
			return 0u;
		trace_node = trace_node->next_nodes[ch2];
	}
	return trace_node->permission;
}


__inline
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
	UNICODE_STRING access_info_file_path = RTL_CONSTANT_STRING(L"\\??\\C:\\Sandcess\\SANDCESS.DAT");

	g_access_info_file = OpenFile(access_info_file_path);
	if (!NT_SUCCESS(g_access_info_file.status))
		g_access_info_file = CreateFile(access_info_file_path);

	g_access_info = (PACCESS_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(ACCESS_INFO), 'AC');
	if (g_access_info == NULL)
	{
		KdPrint(("[Sandcess] -> [AccessController_AccessControllerInitialize] ExAllocatePool2 return null."));
		return STATUS_BREAKPOINT;
	}

	return g_access_info_file.status;
}


VOID
AccessControllerRelease()
{
	if (g_access_info_file.handle != NULL)
		ZwClose(g_access_info_file.handle);
}
