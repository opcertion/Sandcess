#ifndef __TOAST_CONTROLLER_H__
#define __TOAST_CONTROLLER_H__


#include <wintoast/wintoastlib.h>
using namespace WinToastLib;


#define APP_NAME			L"Sandcess"
#define APP_USER_MODEL_ID	L"Sandcess"


class ToastController
{
private:
public:
	ToastController();
	VOID ShowDefaultToast(const std::wstring& content);
	VOID ShowAccessBlockedToast(const std::wstring& content);
};


#endif // !__TOAST_CONTROLLER_H__
