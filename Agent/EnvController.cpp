#include "EnvController.h"


HRESULT EnvController::AddRightClickMenuRegistry()
{
	HKEY h_key = NULL;
	HRESULT h_result = ERROR_SUCCESS;
	const WCHAR right_click_menu_text[] = L"Sandcess Permission Settings";
	const WCHAR right_click_menu_command[] = L"C:\\Sandcess\\Sandcess.exe \"--SetPermission\" \"%1\"";

	for (const std::string &reg_path : {"*\\shell\\"})
	{
		h_result = RegCreateKeyExA(
			HKEY_CLASSES_ROOT,
			(reg_path + "Sandcess").c_str(),
			0,
			NULL,
			0,
			KEY_WRITE,
			NULL,
			&h_key,
			NULL
		);
		if (IS_ERROR(h_result)) goto CLEANUP;


		h_result = RegSetValueExW(
			h_key,
			L"",
			0,
			REG_SZ,
			(LPBYTE)right_click_menu_text,
			(DWORD)wcslen(right_click_menu_text) * sizeof(WCHAR)
		);
		if (IS_ERROR(h_result)) goto CLEANUP;


		h_result = RegCreateKeyExA(
			HKEY_CLASSES_ROOT,
			(reg_path + "Sandcess\\command").c_str(),
			0,
			NULL,
			0,
			KEY_WRITE,
			NULL,
			&h_key,
			NULL
		);
		if (IS_ERROR(h_result)) goto CLEANUP;


		h_result = RegSetValueExW(
			h_key,
			L"",
			0,
			REG_SZ,
			(LPBYTE)right_click_menu_command,
			(DWORD)wcslen(right_click_menu_command) * sizeof(WCHAR)
		);
		if (IS_ERROR(h_result)) goto CLEANUP;
	}

CLEANUP:
	if (h_key)
		RegCloseKey(h_key);
	return h_result;
}


HRESULT EnvController::Setup()
{
	HRESULT h_result;
	h_result = AddRightClickMenuRegistry();
	return h_result;
}
