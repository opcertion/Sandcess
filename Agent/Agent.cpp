#include <windows.h>
#include "EnvController.h"
#include "CommunicationController.h"
#include <iostream>


int wmain(const int argc, const wchar_t* argv[])
{
	HRESULT h_result;


	/* setup */
	if (argc == 2 && lstrcmpiW(argv[1], L"--setup") == 0)
	{
		EnvController env_controller;

		h_result = env_controller.SetupRegistry();
		if (IS_ERROR(h_result)) return -1;

		return 0;
	}


	/* send data */
	if (argc == 3 && lstrcmpiW(argv[1], L"--send") == 0)
	{
		miniflt::CommunicationController comm_controller;

		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result)) return -1;

		miniflt::USER_TO_FLT req; ZeroMemory(&req, sizeof(req));
		miniflt::FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));

		wcsncpy_s(req.buffer, argv[2], MSG_BUFFER_SIZE);
		resp = comm_controller.Send(&req);

		wprintf(L"%s", resp.buffer);
		return 0;
	}
	return 0;
}
