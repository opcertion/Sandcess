#ifndef __STRING_UTILS_H__
#define __STRING_UTILS_H__


#include <ntddk.h>


BOOLEAN
WstringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
);


#endif // !__STRING_UTILS_H__
