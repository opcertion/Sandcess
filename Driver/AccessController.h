#ifndef __ACCESS_CONTROLLER_H__
#define __ACCESS_CONTROLLER_H__


#include <fltKernel.h>


enum ACCESS_TYPE
{
	/* File System */
	READ_FILE = 0,
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
};


NTSTATUS
AccessControllerInitialize();

VOID
AccessControllerRelease();


#endif // !__ACCESS_CONTROLLER_H__
