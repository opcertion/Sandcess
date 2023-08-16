#include "ContainerController.h"


#define CONTAINER_INFO_NEXT_NODES_LENGTH		256
#define IS_CONTAINER_ACTIVATED(_container_id_)	(g_container_activate_state[_container_id_ * (_container_id_ < 0 ? -1 : 1)])


#pragma pack( push, 1 )
typedef struct _CONTAINER_ID_LIST
{
	struct _CONTAINER_ID_LIST_NODE* list;
} CONTAINER_ID_LIST, *PCONTAINER_ID_LIST;
#pragma pack( pop )


#pragma pack( push, 1 )
typedef struct _CONTAINER_ID_LIST_NODE
{
	CHAR container_id;
	struct _CONTAINER_ID_LIST_NODE* next_node;
} CONTAINER_ID_LIST_NODE, *PCONTAINER_ID_LIST_NODE;
#pragma pack( pop )


#pragma pack( push, 1 )
typedef struct _CONTAINER_INFO
{
	struct _CONTAINER_ID_LIST* container_id_list;
	struct _CONTAINER_INFO* next_nodes[CONTAINER_INFO_NEXT_NODES_LENGTH];
} CONTAINER_INFO, *PCONTAINER_INFO;
#pragma pack ( pop )


typedef enum _CONTAINER_PATH_TYPE
{
	TARGET_PATH = 0,
	ACCESSIBLE_PATH
} CONTAINER_PATH_TYPE;


BOOLEAN			g_container_activate_state[MAXIMUM_CONTAINER_ID + 1];
PCONTAINER_INFO	g_container_info = NULL;


PCONTAINER_INFO
GetContainerInfoByPath(
	_In_ PUNICODE_STRING path
)
{
	PCONTAINER_INFO ret = NULL;
	PCONTAINER_INFO trace_node = g_container_info;

	if (path == NULL)
		goto CLEANUP;

	for (SIZE_T idx = 8; idx < path->Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)(path->Buffer[idx] >> 8);
		UCHAR ch2 = (UCHAR)(path->Buffer[idx] & 0x00ff);

		if (trace_node->next_nodes[ch1] == NULL)
			goto CLEANUP;
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
			goto CLEANUP;
		trace_node = trace_node->next_nodes[ch2];
	}
	ret = trace_node;

CLEANUP:
	return ret;
}


PCONTAINER_INFO
CreateContainerInfoByPath(
	_In_ PUNICODE_STRING path
)
{
	PCONTAINER_INFO ret = NULL;
	PCONTAINER_INFO trace_node = g_container_info;

	if (path == NULL)
		goto CLEANUP;

	for (SIZE_T idx = 8; idx < path->Length / sizeof(WCHAR); idx++)
	{
		UCHAR ch1 = (UCHAR)(path->Buffer[idx] >> 8);
		UCHAR ch2 = (UCHAR)(path->Buffer[idx] & 0x00ff);

		if (trace_node->next_nodes[ch1] == NULL)
		{
			trace_node->next_nodes[ch1] = (PCONTAINER_INFO)ExAllocatePool2(
				POOL_FLAG_NON_PAGED,
				sizeof(CONTAINER_INFO),
				'CC'
			);
			if (trace_node->next_nodes[ch1] == NULL)
				goto CLEANUP;
		}
		trace_node = trace_node->next_nodes[ch1];

		if (trace_node->next_nodes[ch2] == NULL)
		{
			trace_node->next_nodes[ch2] = (PCONTAINER_INFO)ExAllocatePool2(
				POOL_FLAG_NON_PAGED,
				sizeof(CONTAINER_INFO),
				'CC'
			);
			if (trace_node->next_nodes[ch2] == NULL)
				goto CLEANUP;
		}
		trace_node = trace_node->next_nodes[ch2];
	}
	ret = trace_node;

CLEANUP:
	return ret;
}


BOOLEAN
InsertContainerId(
	_Inout_	PCONTAINER_INFO		container_info,
	_In_	CHAR				container_id,
	_In_	CONTAINER_PATH_TYPE	container_path_type
)
{
	BOOLEAN ret = FALSE;

	if (container_info == NULL)
		goto CLEANUP;

	if (container_id < 0)
		container_id *= -1;
	if (container_path_type == ACCESSIBLE_PATH)
		container_id *= -1;

	if (container_info->container_id_list == NULL)
	{
		container_info->container_id_list = (PCONTAINER_ID_LIST)ExAllocatePool2(
			POOL_FLAG_NON_PAGED,
			sizeof(CONTAINER_ID_LIST),
			'CC'
		);
		if (container_info->container_id_list == NULL)
			goto CLEANUP;
	}

	if (container_info->container_id_list->list == NULL)
	{
		container_info->container_id_list->list = (PCONTAINER_ID_LIST_NODE)ExAllocatePool2(
			POOL_FLAG_NON_PAGED,
			sizeof(CONTAINER_ID_LIST_NODE),
			'CC'
		);
		if (container_info->container_id_list->list == NULL)
			goto CLEANUP;
		container_info->container_id_list->list->container_id = container_id;
		ret = TRUE;
		goto CLEANUP;
	}
	
	PCONTAINER_ID_LIST_NODE trace_node = container_info->container_id_list->list;
	while (trace_node->next_node != NULL)
	{
		if (!IS_CONTAINER_ACTIVATED(trace_node->container_id))
			trace_node->container_id = 0;
		if (trace_node->container_id == 0)
		{
			trace_node->container_id = container_id;
			ret = TRUE;
			goto CLEANUP;
		}
		if (trace_node->container_id == container_id)
		{
			ret = TRUE;
			goto CLEANUP;
		}
		trace_node = trace_node->next_node;
	}

	PCONTAINER_ID_LIST_NODE next_container_id = (PCONTAINER_ID_LIST_NODE)ExAllocatePool2(
		POOL_FLAG_NON_PAGED,
		sizeof(CONTAINER_ID_LIST_NODE),
		'CC'
	);
	if (next_container_id == NULL)
		goto CLEANUP;
	next_container_id->container_id = container_id;
	trace_node->next_node = next_container_id;
	ret = TRUE;

CLEANUP:
	return ret;
}


BOOLEAN
DeleteContainerId(
	_Inout_	PCONTAINER_INFO		container_info,
	_In_	CHAR				container_id,
	_In_	CONTAINER_PATH_TYPE	container_path_type
)
{
	BOOLEAN ret = FALSE;
	if (
		(container_info == NULL) ||
		(container_info->container_id_list == NULL) ||
		(container_info->container_id_list->list == NULL)
	)
	{
		goto CLEANUP;
	}

	if (container_id < 0)
		container_id *= -1;
	if (container_path_type == ACCESSIBLE_PATH)
		container_id *= -1;

	PCONTAINER_ID_LIST_NODE trace_node = container_info->container_id_list->list;
	do
	{
		if (trace_node->container_id == container_id)
			trace_node->container_id = 0;
		trace_node = trace_node->next_node;
	} while (trace_node != NULL);
	ret = TRUE;

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerIsAllowAccessPathToPath(
	_In_ PUNICODE_STRING target_path,
	_In_ PUNICODE_STRING accessible_path
)
{
	BOOLEAN ret = TRUE;

	if ((target_path == NULL) || (accessible_path == NULL))
		goto CLEANUP;
	
	BOOLEAN target_path_container_ids[MAXIMUM_CONTAINER_ID + 1] = { 0, };
	PUNICODE_STRING container_paths[2] = { target_path, accessible_path };

	for (SIZE_T path_idx = 0; path_idx < 2; path_idx++)
	{
		PCONTAINER_INFO trace_node = g_container_info;

		for (SIZE_T idx = 8; idx < container_paths[path_idx]->Length / sizeof(WCHAR); idx++)
		{
			UCHAR ch1 = (UCHAR)(container_paths[path_idx]->Buffer[idx] >> 8);
			UCHAR ch2 = (UCHAR)(container_paths[path_idx]->Buffer[idx] & 0x00ff);

			if (trace_node->next_nodes[ch1] == NULL)
				goto CLEANUP;
			trace_node = trace_node->next_nodes[ch1];

			if (trace_node->next_nodes[ch2] == NULL)
				goto CLEANUP;
			trace_node = trace_node->next_nodes[ch2];
			
			if ((trace_node->container_id_list != NULL) && (trace_node->container_id_list->list != NULL))
			{
				PCONTAINER_ID_LIST_NODE id_trace_node = trace_node->container_id_list->list;
				do
				{
					if (!IS_CONTAINER_ACTIVATED(id_trace_node->container_id))
						id_trace_node->container_id = 0;
					if (path_idx == 0)
					{
						if (id_trace_node->container_id > 0)
						{
							ret = FALSE;
							target_path_container_ids[id_trace_node->container_id] = TRUE;
						}
					}
					else
					{
						if ((id_trace_node->container_id < 0) && (target_path_container_ids[id_trace_node->container_id * -1]))
						{
							ret = TRUE;
							goto CLEANUP;
						}
					}
					id_trace_node = id_trace_node->next_node;
				} while (id_trace_node != NULL);
			}
		}
	}

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerIsAllowAccessPathToProcessId(
	_In_ PUNICODE_STRING	target_path,
	_In_ HANDLE				accessible_process_id
)
{
	BOOLEAN ret = TRUE;

	if (target_path == NULL || accessible_process_id == NULL)
		goto CLEANUP;

	WCHAR buffer[1024] = { 0, };
	UNICODE_STRING accessible_process_path;
	accessible_process_path.Buffer = buffer;
	accessible_process_path.Length = 0;
	accessible_process_path.MaximumLength = sizeof(buffer);

	if (!GetProcessPathFromProcessId(accessible_process_id, &accessible_process_path))
		goto CLEANUP;
	ret = ContainerControllerIsAllowAccessPathToPath(target_path, &accessible_process_path);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerIsAllowAccessProcessIdToPath(
	_In_ HANDLE				target_process_id,
	_In_ PUNICODE_STRING	accessible_path
)
{
	BOOLEAN ret = TRUE;

	if (target_process_id == NULL || accessible_path == NULL)
		goto CLEANUP;

	WCHAR buffer[1024] = { 0, };
	UNICODE_STRING target_process_path;
	target_process_path.Buffer = buffer;
	target_process_path.Length = 0;
	target_process_path.MaximumLength = sizeof(buffer);

	if (!GetProcessPathFromProcessId(target_process_id, &target_process_path))
		goto CLEANUP;
	ret = ContainerControllerIsAllowAccessPathToPath(&target_process_path, accessible_path);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerIsAllowAccessProcessIdToProcessId(
	_In_ HANDLE target_process_id,
	_In_ HANDLE accessible_process_id
)
{
	BOOLEAN ret = TRUE;

	if (target_process_id == NULL || accessible_process_id == NULL)
		goto CLEANUP;

	WCHAR buffer[1024] = { 0, };
	UNICODE_STRING target_process_path;
	target_process_path.Buffer = buffer;
	target_process_path.Length = 0;
	target_process_path.MaximumLength = sizeof(buffer);

	if (!GetProcessPathFromProcessId(target_process_id, &target_process_path))
		goto CLEANUP;

	RtlZeroMemory(&buffer, sizeof(buffer));
	UNICODE_STRING accessible_process_path;
	accessible_process_path.Buffer = buffer;
	accessible_process_path.Length = 0;
	accessible_process_path.MaximumLength = sizeof(buffer);

	if (!GetProcessPathFromProcessId(accessible_process_id, &accessible_process_path))
		goto CLEANUP;
	ret = ContainerControllerIsAllowAccessPathToPath(&target_process_path, &accessible_process_path);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerCreateContainer(
	_In_ CHAR container_id
)
{
	BOOLEAN ret = FALSE;

	if (!IS_VALID_CONTAINER_ID(container_id))
		goto CLEANUP;

	ret = (!IS_CONTAINER_ACTIVATED(container_id));
	if (ret)
		g_container_activate_state[container_id] = TRUE;

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerDeleteContainer(
	_In_ CHAR container_id
)
{
	BOOLEAN ret = FALSE;

	if (!IS_VALID_CONTAINER_ID(container_id))
		goto CLEANUP;

	ret = (IS_CONTAINER_ACTIVATED(container_id));
	if (ret)
		g_container_activate_state[container_id] = FALSE;

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerAddTargetPath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	target_path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = CreateContainerInfoByPath(target_path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = InsertContainerId(container_info, container_id, TARGET_PATH);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerDeleteTargetPath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	target_path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = GetContainerInfoByPath(target_path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = DeleteContainerId(container_info, container_id, TARGET_PATH);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerAddAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	accessible_path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = CreateContainerInfoByPath(accessible_path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = InsertContainerId(container_info, container_id, ACCESSIBLE_PATH);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerDeleteAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	accessible_path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = GetContainerInfoByPath(accessible_path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = DeleteContainerId(container_info, container_id, ACCESSIBLE_PATH);

CLEANUP:
	return ret;
}


NTSTATUS
ContainerControllerInitialize()
{
	RtlZeroMemory(&g_container_activate_state, sizeof(g_container_activate_state));
	g_container_info = (PCONTAINER_INFO)ExAllocatePool2(POOL_FLAG_NON_PAGED, sizeof(CONTAINER_INFO), 'CC');

	if (g_container_info == NULL)
		return STATUS_UNSUCCESSFUL;
	return STATUS_SUCCESS;
}
