#include "AgentController.h"


VOID
AgentControllerShowAccessBlockedToast(
	_In_ HANDLE			process_id,
	_In_ ACCESS_TYPE	access_type
)
{
	FLT_TO_USER message; RtlZeroMemory(&message, sizeof(message));
	WCHAR buffer[1024] = { 0, };
	UNICODE_STRING process_path;
	process_path.Buffer = buffer;
	process_path.Length = 0;
	process_path.MaximumLength = sizeof(buffer);

	if (!GetProcessPathFromProcessId(process_id, &process_path))
		return;

	message.type = SHOW_ACCESS_BLOCKED_TOAST;
	wcsncpy(message.buffer1, process_path.Buffer, MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR));
	message.buffer2[0] = access_type;
	CommunicationControllerSendMessageToAgent(&message);
}
