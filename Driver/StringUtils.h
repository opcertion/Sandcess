#ifndef __STRING_UTILS_H__
#define __STRING_UTILS_H__


#include <ntddk.h>


BOOLEAN
WideStringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2,
	_In_ SIZE_T max_count
);


BOOLEAN
WideStringStartswith(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2,
	_In_ SIZE_T max_count
);


VOID
UnicodeStringNormalize(
	_Inout_ PUNICODE_STRING str
);


#endif // !__STRING_UTILS_H__
