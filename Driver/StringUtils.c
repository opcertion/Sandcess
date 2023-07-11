#include "StringUtils.h"


BOOLEAN
WstringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
)
{
	SIZE_T wstr1_length = wcslen(wstr1);
	SIZE_T wstr2_length = wcslen(wstr2);
	
	if (wstr1_length != wstr2_length)
		return FALSE;

	for (SIZE_T idx = 0; idx < wstr1_length; idx++)
	{
		if (wstr1[idx] != wstr2[idx])
			return FALSE;
	}
	return TRUE;
}
