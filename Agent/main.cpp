#include <windows.h>
#include <algorithm>
#include <map>
#include "EnvController.h"
#include "CommunicationController.h"
#include "ToastController.h"


int wmain(const int argc, const wchar_t* argv[])
{
	HRESULT h_result;
	ShowWindow(GetConsoleWindow(), SW_HIDE);


	if (argc == 1)
	{
		STARTUPINFO startup_info; ZeroMemory(&startup_info, sizeof(startup_info));
		PROCESS_INFORMATION process_info; ZeroMemory(&process_info, sizeof(process_info));

		if (CreateProcess(L"C:\\Sandcess\\Sandcess.exe", NULL, NULL, NULL, FALSE, 0, NULL, NULL, &startup_info, &process_info))
		{
			CloseHandle(process_info.hProcess);
			CloseHandle(process_info.hThread);
		}
		return 0;
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


	/* start service */
	if (argc == 2 && lstrcmpiW(argv[1], L"--StartService") == 0)
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


	/* show default toast */
	if (argc == 3 && lstrcmpiW(argv[1], L"--ShowDefaultToast") == 0)
	{
		ToastController toast_controller;
		toast_controller.ShowDefaultToast(argv[2]);
		Sleep(15000);
		return 0;
	}


	/* send message */
	if (argc == 4)
	{
		std::map<std::wstring, int> arg1_to_message_type;
		arg1_to_message_type.insert({ L"--setpermission", SET_PERMISSION });
		arg1_to_message_type.insert({ L"--createcontainer", CREATE_CONTAINER });
		arg1_to_message_type.insert({ L"--deletecontainer", DELETE_CONTAINER });
		arg1_to_message_type.insert({ L"--addtargetpath", ADD_TARGET_PATH });
		arg1_to_message_type.insert({ L"--deletetargetpath", DELETE_TARGET_PATH });
		arg1_to_message_type.insert({ L"--addaccessiblepath", ADD_ACCESSIBLE_PATH });
		arg1_to_message_type.insert({ L"--deleteaccessiblepath", DELETE_ACCESSIBLE_PATH });
		std::wstring arg1(argv[1]);
		std::transform(arg1.begin(), arg1.end(), arg1.begin(), towlower);

		CommunicationController comm_controller;
		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result))
			return -1;

		USER_TO_FLT req; ZeroMemory(&req, sizeof(req));
		FLT_TO_USER resp; ZeroMemory(&resp, sizeof(resp));

		req.type = arg1_to_message_type[arg1];
		if (req.type == 0)
			return -1;
		wcsncpy_s(req.buffer1, argv[2], wcsnlen(argv[2], MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)));
		wcsncpy_s(req.buffer2, argv[3], wcsnlen(argv[3], MINIFLT_MSG_BUFFER_SIZE / sizeof(WCHAR)));
		resp = comm_controller.Send(&req);

		return ((req.type == resp.type) ? 0 : -1);
	}
	return -1;
}
