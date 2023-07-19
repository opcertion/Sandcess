#include "StringUtils.h"


BOOLEAN
WstringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
)
{
	const SIZE_T wstr1_length = wcslen(wstr1);
	const SIZE_T wstr2_length = wcslen(wstr2);
	
	if (wstr1_length != wstr2_length)
		return FALSE;

	for (SIZE_T idx = 0; idx < wstr1_length; idx++)
	{
		if (wstr1[idx] != wstr2[idx])
			return FALSE;
	}
	return TRUE;
}


BOOLEAN
WstringStartswith(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2
)
{
	const SIZE_T wstr1_length = wcslen(wstr1);
	const SIZE_T wstr2_length = wcslen(wstr2);

	if (wstr1_length < wstr2_length)
		return FALSE;

	for (SIZE_T idx = 0; idx < wstr2_length; idx++)
	{
		if (wstr1[idx] != wstr2[idx])
			return FALSE;
	}
	return TRUE;
}


PWCHAR
WstringSubstr(
	_In_ PWCHAR wstr,
	_In_ SIZE_T idx1,
	_In_ SIZE_T idx2
)
{
	SIZE_T wstr_length = wcslen(wstr);

	if ((idx2 >= wstr_length) || (idx1 > idx2))
		return NULL;
	
	PWCHAR ret = (PWCHAR)ExAllocatePool2(POOL_FLAG_NON_PAGED, (idx2 - idx1 + 1) * sizeof(WCHAR), 'SU');
	if (ret == NULL)
	{
		KdPrint(("[Sandcess] -> [StringUtils_WstringSubstr] ExAllocatePool2 return null."));
		return NULL;
	}
	RtlCopyMemory(ret, &wstr[idx1], idx2 - 1);
	ret[idx2] = L'\0';
	return ret;
}
