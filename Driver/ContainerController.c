#include "ContainerController.h"


#define CONTAINER_INFO_NEXT_NODES_LENGTH		256
#define IS_CONTAINER_ACTIVATED(_container_id_)	(g_container_activate_state[_container_id_] == TRUE)


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


BOOLEAN			g_container_activate_state[MAXIMUM_CONTAINER_COUNT];
PCONTAINER_INFO	g_container_info	= NULL;


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
	goto CLEANUP;
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


BOOLEAN InsertContainerId(
	_Inout_	PCONTAINER_INFO		container_info,
	_In_	CHAR				container_id,
	_In_	CONTAINER_PATH_TYPE	path_type
)
{
	BOOLEAN ret = FALSE;

	if (container_info == NULL)
		goto CLEANUP;

	if (container_id < 0)
		container_id *= -1;
	if (path_type == ACCESSIBLE_PATH)
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
ContainerControllerCreateContainer(
	_In_ CHAR container_id
)
{
	BOOLEAN ret = FALSE;
	if (container_id > MAXIMUM_CONTAINER_ID)
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
	if (container_id > MAXIMUM_CONTAINER_ID)
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
	_In_ PUNICODE_STRING	path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = CreateContainerInfoByPath(path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = InsertContainerId(container_info, container_id, TARGET_PATH);

CLEANUP:
	return ret;
}


BOOLEAN
ContainerControllerAddAccessiblePath(
	_In_ CHAR				container_id,
	_In_ PUNICODE_STRING	path
)
{
	BOOLEAN ret = FALSE;
	PCONTAINER_INFO container_info = CreateContainerInfoByPath(path);

	if (container_info == NULL)
		goto CLEANUP;
	ret = InsertContainerId(container_info, container_id, ACCESSIBLE_PATH);

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
