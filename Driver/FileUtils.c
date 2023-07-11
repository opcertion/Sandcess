#include "FileUtils.h"


FILE
OpenFile(
	_In_ UNICODE_STRING file_path
)
{
	FILE file; RtlZeroMemory(&file, sizeof(file));

	InitializeObjectAttributes(
		&file.object_attributes,
		&file_path,
		OBJ_KERNEL_HANDLE | OBJ_CASE_INSENSITIVE,
		NULL,
		NULL
	);

	file.status = ZwOpenFile(
		&file.handle,
		FILE_GENERIC_READ | FILE_GENERIC_WRITE,
		&file.object_attributes,
		&file.io_status_block,
		FILE_SHARE_READ,
		FILE_NON_DIRECTORY_FILE
	);
	return file;
}


FILE
CreateFile(
	_In_ UNICODE_STRING file_path
)
{
	FILE file; RtlZeroMemory(&file, sizeof(file));

	InitializeObjectAttributes(
		&file.object_attributes,
		&file_path,
		OBJ_KERNEL_HANDLE | OBJ_CASE_INSENSITIVE,
		NULL,
		NULL
	);

	file.status = ZwCreateFile(
		&file.handle,
		FILE_GENERIC_READ | FILE_GENERIC_WRITE,
		&file.object_attributes,
		&file.io_status_block,
		NULL,
		FILE_ATTRIBUTE_NORMAL,
		0,
		FILE_CREATE,
		FILE_SYNCHRONOUS_IO_NONALERT,
		NULL,
		0
	);
	return file;
}


SIZE_T
ReadFile(
	_Out_ PFILE			file,
	_Out_ PFILE_DATA	output_file_data
)
{
	RtlZeroMemory(output_file_data, sizeof(*output_file_data));
	WCHAR buffer[1] = { 0x00 };
	NTSTATUS status;
	SIZE_T file_data_size = 0u;

	for (; file_data_size < FILE_DATA_BUFFER_SIZE; file_data_size += sizeof(WCHAR))
	{
		status = ZwReadFile(
			file->handle,
			NULL,
			NULL,
			NULL,
			&file->io_status_block,
			buffer,
			sizeof(WCHAR),
			&file->byte_offset,
			NULL
		);
		if (!NT_SUCCESS(status))
			break;
		output_file_data->buffer[file_data_size / sizeof(WCHAR)] = buffer[0];
		file->byte_offset.QuadPart += sizeof(WCHAR);
	}
	file->byte_offset.QuadPart = 0uLL;
	return file_data_size;
}


VOID
WriteFile(
	_Out_	PFILE	file,
	_In_	PVOID	buffer,
	_In_	ULONG	buffer_size
)
{
	file->status = ZwWriteFile(
		file->handle,
		NULL,
		NULL,
		NULL,
		&file->io_status_block,
		buffer,
		buffer_size,
		NULL,
		NULL
	);
}


BOOLEAN
IsEof(
	_In_ PFILE file
)
{
	WCHAR buffer[1] = { 0x00 };
	NTSTATUS status = ZwReadFile(
		file->handle,
		NULL,
		NULL,
		NULL,
		&file->io_status_block,
		buffer,
		sizeof(WCHAR),
		&file->byte_offset,
		NULL
	);
	return !NT_SUCCESS(status);
}


VOID
CloseFile(
	_In_ PFILE file
)
{
	if (file->handle)
	{
		ZwClose(
			file->handle
		);
	}
	RtlZeroMemory(file, sizeof(*file));
}
