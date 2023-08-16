#ifndef __ACCESS_CONTROLLER_H__
#define __ACCESS_CONTROLLER_H__


#include <fltKernel.h>
#include "ProcessUtils.h"
#include "StringUtils.h"


#define IS_ALLOW_ACCESS(_permission_, _access_type_) ((_permission_ >> _access_type_) & 1)


typedef enum _ACCESS_TYPE
{
	/* File System */
	READ_FILE = 2,
	WRITE_FILE,
	MOVE_FILE,
	/* Process */
	CREATE_PROCESS,
	/* Network */
	SEND_PACKET,
	RECV_PACKET,
} ACCESS_TYPE;


BOOLEAN
AccessControllerSetPermissionByPath(
	_In_ PUNICODE_STRING	path,
	_In_ UINT32				permission
);


UINT32
AccessControllerGetPermissionByPath(
	_In_ PUNICODE_STRING path
);


BOOLEAN
AccessControllerSetPermissionByProcessId(
	_In_ HANDLE			process_id,
	_In_ UINT32			permission
);


UINT32
AccessControllerGetPermissionByProcessId(
	_In_ HANDLE			process_id
);


VOID
AccessControllerRemovePermissionByProcessId(
	_In_ HANDLE			process_id
);


NTSTATUS
AccessControllerInitialize();


VOID
AccessControllerRelease();


#endif // !__ACCESS_CONTROLLER_H__
