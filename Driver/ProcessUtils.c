#include "ProcessUtils.h"


typedef NTSTATUS(*ZW_QUERY_INFORMATION_PROCESS) (
	_In_      HANDLE           ProcessHandle,
	_In_      PROCESSINFOCLASS ProcessInformationClass,
	_Out_     PVOID            ProcessInformation,
	_In_      ULONG            ProcessInformationLength,
	_Out_opt_ PULONG           ReturnLength
);
ZW_QUERY_INFORMATION_PROCESS ZwQueryInformationProcess = NULL;


#pragma warning( push )
#pragma warning( disable:6101 )
BOOLEAN
GetProcessPathFromProcessId(
	_In_	HANDLE			process_id,
	_Out_	PUNICODE_STRING	process_path
)
{
	BOOLEAN ret = FALSE;
	HANDLE process_handle = NULL;
	PVOID buffer = NULL;
	PEPROCESS process; RtlZeroMemory(&process, sizeof(process));
	NTSTATUS status = STATUS_SUCCESS;

	if (ZwQueryInformationProcess == NULL)
	{
		UNICODE_STRING routine_name = RTL_CONSTANT_STRING(L"ZwQueryInformationProcess");
		ZwQueryInformationProcess = (ZW_QUERY_INFORMATION_PROCESS)MmGetSystemRoutineAddress(&routine_name);

		if (ZwQueryInformationProcess == NULL)
			goto CLEANUP;
	}

	status = PsLookupProcessByProcessId(process_id, &process);
	if (!NT_SUCCESS(status))
		goto CLEANUP;
	status = ObOpenObjectByPointer(process, 0, NULL, 0, 0, KernelMode, &process_handle);
	if (!NT_SUCCESS(status))
		goto CLEANUP;
	ObDereferenceObject(process);

	ULONG returned_length = 0;
	status = ZwQueryInformationProcess(
		process_handle,
		ProcessImageFileName,
		NULL,
		0,
		&returned_length
	);

	if ((status != STATUS_INFO_LENGTH_MISMATCH) || (process_path->MaximumLength < returned_length))
		goto CLEANUP;

	buffer = (PVOID)ExAllocatePool2(POOL_FLAG_NON_PAGED, returned_length, 'PU');
	if (buffer == NULL)
		goto CLEANUP;

	status = ZwQueryInformationProcess(
		process_handle,
		ProcessImageFileName,
		buffer,
		returned_length,
		&returned_length
	);
	if (!NT_SUCCESS(status))
		goto CLEANUP;
	
	RtlCopyUnicodeString(process_path, (PUNICODE_STRING)buffer);
	ret = TRUE;

CLEANUP:
	if (process_handle)
		ZwClose(process_handle);
	if (buffer)
		ExFreePool(buffer);
	return ret;
}
#pragma warning( pop )
