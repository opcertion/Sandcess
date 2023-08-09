#include <windows.h>
#include "EnvController.h"
#include "CommunicationController.h"
#include "ToastController.h"
#include <iostream>


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
		if (IS_ERROR(h_result)) return -1;

		ToastController toast_controller;
		HANDLE port_handle = comm_controller.GetPortHandle();

		while (1)
		{
			FLT_TO_USER_WITH_HEADER resp; ZeroMemory(&resp, sizeof(resp));
			h_result = FilterGetMessage(
				port_handle,
				&resp.header,
				sizeof(resp),
				nullptr
			);
			if (IS_ERROR(h_result)) continue;
			try
			{
				std::wstring message(resp.message.buffer);
				if (message.rfind(L"ShowAccessBlockedToast ", 0) == 0)
					toast_controller.ShowAccessBlockedToast(message.substr(23));
			}
			catch (...) { }
		}
	}


	/* setup */
	if (argc == 2 && lstrcmpiW(argv[1], L"--setup") == 0)
	{
		EnvController env_controller;

		h_result = env_controller.Setup();
		if (IS_ERROR(h_result)) return -1;

		ToastController toast_controller;
		toast_controller.ShowDefaultToast(L"Sandcess is ready to use!");
		Sleep(15000);
		return 0;
	}


	/* send data */
	if (argc == 3 && lstrcmpiW(argv[1], L"--send") == 0)
	{
		CommunicationController comm_controller;

		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result)) return -1;

		USER_TO_FLT req; ZeroMemory(&req, sizeof(req));
		FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));
		
		wcsncpy_s(req.buffer, argv[2], wcsnlen(argv[2], MSG_BUFFER_SIZE / sizeof(WCHAR)));
		resp = comm_controller.Send(&req);

		wprintf(L"%s", resp.buffer);
		return 0;
	}


	/* show default toast */
	if (argc == 3 && lstrcmpiW(argv[1], L"--showDefaultToast") == 0)
	{
		ToastController toast_controller;
		toast_controller.ShowDefaultToast(argv[2]);
		Sleep(15000);
		return 0;
	}
	return 0;
}
