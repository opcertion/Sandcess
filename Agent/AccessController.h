#ifndef __ACCESS_CONTROLLER_H__
#define __ACCESS_CONTROLLER_H__


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


#endif // !__ACCESS_CONTROLLER_H__
