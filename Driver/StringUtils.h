#ifndef __STRING_UTILS_H__
#define __STRING_UTILS_H__


#include <ntddk.h>


BOOLEAN
WideStringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
);

BOOLEAN
WideStringStartswith(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
);

PWCHAR
WideStringSubstr(
	_In_ PWCHAR wstr,
	_In_ SIZE_T idx1,
	_In_ SIZE_T idx2
);


VOID
UnicodeStringNormalize(
	_Inout_ PUNICODE_STRING str
);


#endif // !__STRING_UTILS_H__
