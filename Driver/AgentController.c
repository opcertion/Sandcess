#include "AgentController.h"


VOID
AgentControllerShowAccessBlockedToast(
	_In_ PWCHAR content
)
{
	FLT_TO_USER message; RtlZeroMemory(&message, sizeof(message));
	
	wcscpy(message.buffer, L"ShowAccessBlockedToast ");
	wcsncpy(
		&message.buffer[23],
		content, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR) - 24
	);
	CommunicationControllerSendMessageToAgent(&message);
}
