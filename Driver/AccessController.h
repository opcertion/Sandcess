#ifndef __ACCESS_CONTROLLER_H__
#define __ACCESS_CONTROLLER_H__


#include <fltKernel.h>
#include "FileUtils.h"


typedef enum _ACCESS_TYPE
{
	__RESERVED1 = 0,
	__RESERVED2,
	/* File System */
	READ_FILE,
	WRITE_FILE,
	CREATE_FILE,
	DELETE_FILE,
	MOVE_FILE,
	CREATE_DIRECTORY,
	DELETE_DIRECTORY,
	OPEN_DIRECTORY,
	/* Network */
	SEND_PACKET,
	RECV_PACKET,
	/* Process */
	CREATE_PROCESS,
	RUN_PROCESS,
	KILL_PROCESS,
	__DUMMY1,
	__DUMMY2,
	__DUMMY3,
	__DUMMY4,
	__DUMMY5,
	__DUMMY6,
	__DUMMY7,
	__DUMMY8,
	__DUMMY9,
	__DUMMY10,
	__DUMMY11,
	__DUMMY12,
	__DUMMY13,
	__DUMMY14,
	__DUMMY15,
	__RESERVED3,
	__RESERVED4
} ACCESS_TYPE;


BOOLEAN
AccessControllerSetPermission(
	_In_ UNICODE_STRING path,
	_In_ UINT32			permission
);

UINT32
AccessControllerGetPermission(
	_In_ UNICODE_STRING path
);

__inline
BOOLEAN
AccessControllerIsAllowAccess(
	_In_ UINT32			permission,
	_In_ ACCESS_TYPE	access_type
);

NTSTATUS
AccessControllerInitialize();

VOID
AccessControllerRelease();


#endif // !__ACCESS_CONTROLLER_H__
