#include <windows.h>
#include "EnvController.h"
#include "CommunicationController.h"
#include "ToastController.h"


int wmain(const int argc, const wchar_t* argv[])
{
	HRESULT h_result;
	ShowWindow(GetConsoleWindow(), SW_HIDE);


	/* background service */
	if (argc == 1)
	{
		CreateMutexA(0, FALSE, "Local\\SandcessAgent");
		if (GetLastError() == ERROR_ALREADY_EXISTS)
			return -1;

		CommunicationController comm_controller;
		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result))
			return -1;

		while (1) { comm_controller.ProcessRequest(); }
	}


	/* setup */
	if (argc == 2 && lstrcmpiW(argv[1], L"--Setup") == 0)
	{
		EnvController env_controller;

		h_result = env_controller.Setup();
		if (IS_ERROR(h_result)) return -1;

		ToastController toast_controller;
		toast_controller.ShowDefaultToast(L"Sandcess is ready to use!");
		Sleep(15000);
		return 0;
	}


	/* set permission */
	if (argc == 4 && lstrcmpiW(argv[1], L"--SetPermission") == 0)
	{
		CommunicationController comm_controller;

		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result)) return -1;

		USER_TO_FLT req; ZeroMemory(&req, sizeof(req));
		FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));

		req.type = SET_PERMISSION;
		wcsncpy_s(req.buffer1, argv[2], wcsnlen(argv[2], MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)));
		wcsncpy_s(req.buffer2, argv[3], wcsnlen(argv[3], MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)));
		resp = comm_controller.Send(&req);

		return ((req.type == resp.type) ? 0 : -1);
	}


	/* show default toast */
	if (argc == 3 && lstrcmpiW(argv[1], L"--ShowDefaultToast") == 0)
	{
		ToastController toast_controller;
		toast_controller.ShowDefaultToast(argv[2]);
		Sleep(15000);
		return 0;
	}
	return 0;
}
