#ifndef __CONTAINER_CONTROLLER_H__
#define __CONTAINER_CONTROLLER_H__


#include "ProcessUtils.h"


#define MAXIMUM_CONTAINER_COUNT					100
#define MAXIMUM_CONTAINER_ID					MAXIMUM_CONTAINER_COUNT
#define IS_VALID_CONTAINER_ID(_container_id_)	((_container_id_ >= 1) && (_container_id_ <= MAXIMUM_CONTAINER_ID))


BOOLEAN
ContainerControllerIsAllowAccessPathToPath(
	_In_ PUNICODE_STRING target_path,
	_In_ PUNICODE_STRING accessible_path
);


BOOLEAN
ContainerControllerIsAllowAccessPathToProcessId(
	_In_ PUNICODE_STRING	target_path,
	_In_ HANDLE				accessible_process_id
);


BOOLEAN
ContainerControllerIsAllowAccessProcessIdToPath(
	_In_ HANDLE				target_process_id,
	_In_ PUNICODE_STRING	accessible_path
);


BOOLEAN
ContainerControllerIsAllowAccessProcessIdToProcessId(
	_In_ HANDLE target_process_id,
	_In_ HANDLE accessible_process_id
);


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
	_In_ PUNICODE_STRING	target_path
);


BOOLEAN
ContainerControllerDeleteTargetPath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	target_path
);


BOOLEAN
ContainerControllerAddAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	accessible_path
);


BOOLEAN
ContainerControllerDeleteAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	accessible_path
);


NTSTATUS
ContainerControllerInitialize();


#endif // !__CONTAINER_CONTROLLER_H__
