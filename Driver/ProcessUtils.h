#ifndef __PROCESS_UTILS_H__
#define __PROCESS_UTILS_H__


#include <fltKernel.h>
#include "StringUtils.h"


UNICODE_STRING
GetProcessPathFromProcessId(
	_In_ CONST HANDLE process_id
);


#endif // !__PROCESS_UTILS_H__
