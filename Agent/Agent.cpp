#include <windows.h>
#include "CommunicationController.h"
#include <iostream>

int main(const int argc, const char* argv[])
{
	miniflt::CommunicationController comm_controller;
	HRESULT h_result;

	h_result = comm_controller.Connect();
	if (IS_ERROR(h_result))
		return -1;

	miniflt::USER_TO_FLT req = { L"" };
	miniflt::USER_TO_FLT_REPLY reply;
	reply = comm_controller.Send(&req);

	std::wcout << reply.msg << L"\n";

	return 0;
}
