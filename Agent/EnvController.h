#ifndef __ENV_CONTROLLER_H__
#define __ENV_CONTROLLER_H__


#include <windows.h>
#include <string>


class EnvController
{
private:
	HRESULT AddRightClickMenuRegistry();

public:
	HRESULT Setup();
};


#endif // !__ENV_CONTROLLER_H__
