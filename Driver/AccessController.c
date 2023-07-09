#include "AccessController.h"

#pragma pack(push, 1)
typedef struct _ACCESS_INFO_FILE
{
	HANDLE handle;
	OBJECT_ATTRIBUTES object_attributes;
	IO_STATUS_BLOCK io_status_block;
} ACCESS_INFO_FILE, *PACCESS_INFO_FILE;
#pragma pack(pop)


ACCESS_INFO_FILE g_access_info_file = { NULL, };


NTSTATUS
AccessControllerInitialize()
{
	NTSTATUS status = STATUS_SUCCESS;
	UNICODE_STRING file_path = RTL_CONSTANT_STRING(L"\\??\\C:\\SANDCESS.DAT");
	RtlZeroMemory(&g_access_info_file, sizeof(g_access_info_file));
	
	InitializeObjectAttributes(
		&g_access_info_file.object_attributes,
		&file_path,
		OBJ_KERNEL_HANDLE | OBJ_CASE_INSENSITIVE,
		NULL,
		NULL
	);

	status = ZwOpenFile(
		&g_access_info_file.handle,
		FILE_GENERIC_READ | FILE_GENERIC_WRITE,
		&g_access_info_file.object_attributes,
		&g_access_info_file.io_status_block,
		FILE_SHARE_READ,
		FILE_NON_DIRECTORY_FILE
	);
	
	if (!NT_SUCCESS(status))
	{
		status = ZwCreateFile(
			&g_access_info_file.handle,
			FILE_GENERIC_READ | FILE_GENERIC_WRITE,
			&g_access_info_file.object_attributes,
			&g_access_info_file.io_status_block,
			NULL,
			FILE_ATTRIBUTE_NORMAL,
			0,
			FILE_CREATE,
			FILE_SYNCHRONOUS_IO_NONALERT,
			NULL,
			0
		);
	}
	return status;
}

/*
	WCHAR buffer[] = L"";
	status = ZwWriteFile(
		g_access_info_file.handle,
		NULL,
		NULL,
		NULL,
		&io_status_block,
		(PVOID)buffer,
		(ULONG)(wcslen(buffer) * sizeof(WCHAR)),
		NULL,
		NULL
	);
*/

VOID
AccessControllerRelease()
{
	if (g_access_info_file.handle != NULL)
		ZwClose(g_access_info_file.handle);
}
