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


	/* send data to driver */
	if (argc == 3 && lstrcmpiW(argv[1], L"--send") == 0)
	{
		miniflt::CommunicationController comm_controller;

		h_result = comm_controller.Connect();
		if (IS_ERROR(h_result)) return -1;

		miniflt::USER_TO_FLT req = { L"" };
		miniflt::USER_TO_FLT_REPLY reply;
		reply = comm_controller.Send(&req);

		std::wcout << reply.msg << L"\n";
		return 0;
	}
	return 0;
}
