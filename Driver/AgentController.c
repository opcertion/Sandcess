#include "AgentController.h"


VOID
AgentControllerShowAccessBlockedToast(
	_In_ PWCHAR			path,
	_In_ ACCESS_TYPE	access_type
)
{
	FLT_TO_USER message; RtlZeroMemory(&message, sizeof(message));
	
	message.type = SHOW_ACCESS_BLOCKED_TOAST;
	wcsncpy(message.buffer1, path, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR));
	message.buffer2[0] = access_type;
	CommunicationControllerSendMessageToAgent(&message);
}
