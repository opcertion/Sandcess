#ifndef __PROCESS_UTILS_H__
#define __PROCESS_UTILS_H__


#include <fltKernel.h>
#include "StringUtils.h"


BOOLEAN
GetProcessPathFromProcessId(
	_In_	HANDLE			process_id,
	_Out_	PUNICODE_STRING	process_path
);


#endif // !__PROCESS_UTILS_H__
