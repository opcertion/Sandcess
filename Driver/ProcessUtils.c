#include "ProcessUtils.h"


typedef NTSTATUS(*QUERY_INFO_PROCESS) (
	__in HANDLE ProcessHandle,
	__in PROCESSINFOCLASS ProcessInformationClass,
	__out_bcount(ProcessInformationLength) PVOID ProcessInformation,
	__in ULONG ProcessInformationLength,
	__out_opt PULONG ReturnLength
);
QUERY_INFO_PROCESS ZwQueryInformationProcess = NULL;


UNICODE_STRING
GetProcessPathFromProcessId(
	_In_ HANDLE process_id
)
{
	UNICODE_STRING ret; RtlZeroMemory(&ret, sizeof(ret));
	
	if (ZwQueryInformationProcess == NULL)
	{
		UNICODE_STRING routine_name;
		RtlInitUnicodeString(&routine_name, L"ZwQueryInformationProcess");
		ZwQueryInformationProcess = (QUERY_INFO_PROCESS)MmGetSystemRoutineAddress(&routine_name);

		if (ZwQueryInformationProcess == NULL)
			goto CLEANUP;
	}

	HANDLE process_handle; RtlZeroMemory(&process_handle, sizeof(process_handle));
	PEPROCESS process; RtlZeroMemory(&process, sizeof(process));
	NTSTATUS status = STATUS_SUCCESS;

	status = PsLookupProcessByProcessId(process_id, &process);
	if (!NT_SUCCESS(status))
		goto CLEANUP;
	status = ObOpenObjectByPointer(process, 0, NULL, 0, 0, KernelMode, &process_handle);
	if (!NT_SUCCESS(status))
		goto CLEANUP;
	ObDereferenceObject(process);

	WCHAR buffer[4096 / sizeof(WCHAR)]; RtlZeroMemory(&buffer, sizeof(buffer));
	ULONG returned_length = 0u;
	ZwQueryInformationProcess(
		process_handle,
		ProcessImageFileName,
		&buffer,
		sizeof(buffer),
		&returned_length
	);
	PWCHAR process_path = (PWCHAR)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(buffer), 'PU');
	if (process_path == NULL)
	{
		KdPrint(("[Sandcess] -> [ProcessUtils_GetProcessPathFromProcessId] ExAllocatePool2 return null."));
		goto CLEANUP;
	}

	RtlCopyMemory(process_path, &buffer[8], sizeof(buffer) - (8 * sizeof(WCHAR)));
	ret.Buffer = process_path;
	ret.Length = (USHORT)returned_length;
	ret.MaximumLength = sizeof(buffer);
	
CLEANUP:
	return ret;
}
