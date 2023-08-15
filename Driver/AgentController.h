#ifndef __AGENT_CONTROLLER_H__
#define __AGENT_CONTROLLER_H__


#include "CommunicationController.h"
#include "ProcessUtils.h"


VOID
AgentControllerShowAccessBlockedToast(
	_In_ HANDLE			process_id,
	_In_ ACCESS_TYPE	access_type
);


#endif // !__AGENT_CONTROLLER_H__
