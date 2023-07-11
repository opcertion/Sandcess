#include "AccessController.h"


FILE g_access_info_file;


NTSTATUS
AccessControllerInitialize()
{
	RtlZeroMemory(&g_access_info_file, sizeof(g_access_info_file));
	UNICODE_STRING access_info_file_path = RTL_CONSTANT_STRING(L"\\??\\C:\\Sandcess\\SANDCESS.DAT");

	g_access_info_file = OpenFile(access_info_file_path);
	if (!NT_SUCCESS(g_access_info_file.status))
		g_access_info_file = CreateFile(access_info_file_path);
	return g_access_info_file.status;
}


VOID
AccessControllerRelease()
{
	if (g_access_info_file.handle != NULL)
		ZwClose(g_access_info_file.handle);
}
