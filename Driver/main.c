#include "pch.h"


UNICODE_STRING g_device_name = RTL_CONSTANT_STRING(L"\\Device\\Sandcess");
UNICODE_STRING g_dos_device_name = RTL_CONSTANT_STRING(L"\\DosDevices\\Sandcess");

PDEVICE_OBJECT g_device_object = NULL;


VOID DriverUnload(_In_ PDRIVER_OBJECT driver_object);
VOID Cleanup();


NTSTATUS
DriverEntry(
	_In_ PDRIVER_OBJECT		driver_object,
	_In_ PUNICODE_STRING	registry_path
)
{
	UNREFERENCED_PARAMETER(registry_path);
	NTSTATUS status = STATUS_SUCCESS;

	driver_object->DriverUnload = DriverUnload;

	status = IoCreateDevice(
		driver_object,
		0,
		&g_dos_device_name,
		FILE_DEVICE_DISK,
		0,
		FALSE,
		&g_device_object
	);
	CHECK_ERROR(IoCreateDevice, status, CLEANUP);
	status = IoCreateSymbolicLink(&g_device_name, &g_dos_device_name);
	CHECK_ERROR(IoCreateSymbolicLink, status, CLEANUP);


	// ==================== [ Sync ] ====================
	SyncMutexInitialize();


	// ==================== [ Access Controller ] ====================
	status = AccessControllerInitialize();
	CHECK_ERROR(AcesssControllerInitialize, status, CLEANUP);


	// ==================== [ Minifilter Controller ] ====================
	status = MinifltControllerInitialize(driver_object);
	CHECK_ERROR(MinifltControllerInitialize, status, CLEANUP);


	// ==================== [ File System Controller ] ====================
	status = FileSystemControllerInitialize(g_flt_handle);
	CHECK_ERROR(FileSystemControllerInitialize, status, CLEANUP);


	// ==================== [ Communication Port ] ====================
	status = CommunicationControllerInitialize(g_flt_handle);
	CHECK_ERROR(CommunicationControllerInitialize, status, CLEANUP);


	// ==================== [ Process Controller ] ====================
	status = ProcessControllerInitialize();
	CHECK_ERROR(ProcessControllerInitialize, status, CLEANUP);


	return STATUS_SUCCESS;

CLEANUP:
	Cleanup();
	return status; // NT_ERROR
}


VOID
DriverUnload(
	_In_ PDRIVER_OBJECT driver_object
)
{
	UNREFERENCED_PARAMETER(driver_object);

	if (g_device_object != NULL)
		IoDeleteDevice(g_device_object);
	Cleanup();
}


VOID
Cleanup()
{
	AccessControllerRelease();
	ProcessControllerRelease();
	ProcessHolderRelease();
	SyncFastMutexUnlock();
}
