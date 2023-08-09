#ifndef __ACCESS_CONTROLLER_H__
#define __ACCESS_CONTROLLER_H__


#include <fltKernel.h>
#include "StringUtils.h"
#include "FileUtils.h"
#include "sync.h"


typedef enum _ACCESS_TYPE
{
	__RESERVED1 = 0,
	__RESERVED2,
	/* File System */
	READ_FILE,
	WRITE_FILE,
	MOVE_FILE,
	/* Process */
	CREATE_PROCESS,
	KILL_PROCESS,
	/* Network */
	SEND_PACKET,
	RECV_PACKET,
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
	__DUMMY16,
	__DUMMY17,
	__DUMMY18,
	__DUMMY19,
	__DUMMY20,
	__DUMMY21,
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
