#include "ToastController.h"


class DefaultToastHandler : public IWinToastHandler
{
private:
public:
	void toastActivated() const { }
	void toastActivated(int actionIndex) const { }
	void toastDismissed(WinToastDismissalReason state) const { }
	void toastFailed() const { }
};


class AccessBlockedToastHandler : public IWinToastHandler
{
private:
public:
	void toastActivated() const
	{

	}
	
	void toastActivated(int actionIndex) const
	{

	}
	
	void toastDismissed(WinToastDismissalReason state) const
	{

	}

	void toastFailed() const
	{

	}
};



ToastController::ToastController()
{
	WinToast::instance()->setAppName(APP_NAME);
	WinToast::instance()->setAppUserModelId(APP_USER_MODEL_ID);
	WinToast::instance()->initialize();
}


VOID ToastController::ShowDefaultToast(const std::wstring& content)
{
	WinToastTemplate toast_template = WinToastTemplate(WinToastTemplate::ImageAndText01);
	toast_template.setTextField(content, WinToastTemplate::FirstLine);
	WinToast::instance()->showToast(toast_template, new DefaultToastHandler());
}


VOID ToastController::ShowAccessBlockedToast(const std::wstring& content)
{
	WinToastTemplate toast_template = WinToastTemplate(WinToastTemplate::ImageAndText01);
	toast_template.setTextField(content, WinToastTemplate::FirstLine);

	std::vector<std::wstring> actions;
	actions.push_back(L"Open settings");
	actions.push_back(L"Ok");

	for (auto const& action : actions)
		toast_template.addAction(action);
	WinToast::instance()->showToast(toast_template, new AccessBlockedToastHandler());
}

