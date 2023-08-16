#ifndef __CONTAINER_CONTROLLER_H__
#define __CONTAINER_CONTROLLER_H__


#include <ntddk.h>


#define MAXIMUM_CONTAINER_COUNT		100
#define MAXIMUM_CONTAINER_ID		(MAXIMUM_CONTAINER_COUNT - 1)


BOOLEAN
ContainerControllerCreateContainer(
	_In_ CHAR container_id
);


BOOLEAN
ContainerControllerDeleteContainer(
	_In_ CHAR container_id
);


BOOLEAN
ContainerControllerAddTargetPath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
);


BOOLEAN
ContainerControllerAddAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
);


NTSTATUS
ContainerControllerInitialize();


#endif // !__CONTAINER_CONTROLLER_H__
