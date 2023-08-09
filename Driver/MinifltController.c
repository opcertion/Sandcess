#include "MinifltController.h"


/* extern */ PFLT_FILTER g_flt_handle = NULL;


NTSTATUS
MinifltUnload(
	_In_ FLT_FILTER_UNLOAD_FLAGS flags
)
{
	UNREFERENCED_PARAMETER(flags);

	if (g_flt_handle)
		FltUnregisterFilter(g_flt_handle);
	return STATUS_SUCCESS;
}


FLT_OPERATION_REGISTRATION g_flt_operations[] = {
	{
		IRP_MJ_CREATE,						// Major Function
		0,									// Flags
		MinifltCreatePreRoutine,			// Pre Operation
		MinifltCreatePostRoutine,			// Post Operation
		NULL
	},
	{
		IRP_MJ_READ,
		0,
		MinifltCreatePreRoutine,
		MinifltCreatePostRoutine,
		NULL
	},
	{
		IRP_MJ_SET_INFORMATION,
		0,
		MinifltCreatePreRoutine,
		MinifltCreatePostRoutine,
		NULL
	},
	{ IRP_MJ_OPERATION_END }
};
FLT_REGISTRATION g_flt_registration = {
	sizeof(FLT_REGISTRATION),				// Size
	FLT_REGISTRATION_VERSION,				// Version
	0,										// Flags
	NULL,									// Context Registration
	g_flt_operations,						// Operation Registration
	MinifltUnload,							// Filter Unload Callback
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL,
	NULL
};


NTSTATUS
MinifltControllerInitialize(
	_In_ PDRIVER_OBJECT driver_object
)
{
	return FltRegisterFilter(
		driver_object,
		&g_flt_registration,
		&g_flt_handle
	);
}
