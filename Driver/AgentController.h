#ifndef __AGENT_CONTROLLER_H__
#define __AGENT_CONTROLLER_H__


#include "CommunicationController.h"


VOID
AgentControllerShowAccessBlockedToast(
	_In_ PWCHAR			path,
	_In_ ACCESS_TYPE	access_type
);


#endif // !__AGENT_CONTROLLER_H__
