#ifndef __FILE_UTILS_H__
#define __FILE_UTILS_H__


#include <fltKernel.h>


#define FILE_DATA_BUFFER_SIZE 2048

typedef struct _FILE
{
	NTSTATUS status;
	HANDLE handle;
	OBJECT_ATTRIBUTES object_attributes;
	IO_STATUS_BLOCK io_status_block;
	LARGE_INTEGER byte_offset;
} FILE, *PFILE;

typedef struct _FILE_DATA
{
	WCHAR buffer[FILE_DATA_BUFFER_SIZE / sizeof(WCHAR)];
} FILE_DATA, *PFILE_DATA;


FILE
OpenFile(
	_In_ UNICODE_STRING file_path
);

FILE
CreateFile(
	_In_ UNICODE_STRING file_path
);

SIZE_T
ReadFile(
	_Out_ PFILE			file,
	_Out_ PFILE_DATA	file_data
);

VOID
WriteFile(
	_Out_	PFILE	file,
	_In_	PVOID	buffer,
	_In_	ULONG	buffer_size
);

BOOLEAN
IsEof(
	_In_ PFILE file
);

VOID
CloseFile(
	_In_ PFILE file
);


#endif // !__FILE_UTILS_H__
