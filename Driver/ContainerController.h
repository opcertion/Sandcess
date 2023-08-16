#ifndef __CONTAINER_CONTROLLER_H__
#define __CONTAINER_CONTROLLER_H__


#include <ntddk.h>


#define MAXIMUM_CONTAINER_COUNT					100
#define MAXIMUM_CONTAINER_ID					MAXIMUM_CONTAINER_COUNT
#define IS_VALID_CONTAINER_ID(_container_id_)	((_container_id_ >= 1) && (_container_id_ <= MAXIMUM_CONTAINER_ID))


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
ContainerControllerDeleteTargetPath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
);


BOOLEAN
ContainerControllerAddAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
);


BOOLEAN
ContainerControllerDeleteAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
);


NTSTATUS
ContainerControllerInitialize();


#endif // !__CONTAINER_CONTROLLER_H__
