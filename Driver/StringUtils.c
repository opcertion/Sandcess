#include "StringUtils.h"


BOOLEAN
WideStringEqual(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2,
	_In_ SIZE_T max_count
)
{
	PWCHAR wstr1_ptr = wstr1;
	PWCHAR wstr2_ptr = wstr2;
	SIZE_T ch_cnt = 0;

	while (*wstr1_ptr == *wstr2_ptr)
	{
		if (*wstr1_ptr == L'\0')
			return TRUE;
		wstr1_ptr += 2;
		wstr2_ptr += 2;
		ch_cnt += 1;
		if (ch_cnt > max_count)
			return FALSE;
	}
	return FALSE;
}


BOOLEAN
WideStringStartswith(
	_In_ PWCHAR wstr1,
	_In_ PWCHAR wstr2,
	_In_ SIZE_T max_count
)
{
	PWCHAR wstr1_ptr = wstr1;
	PWCHAR wstr2_ptr = wstr2;
	SIZE_T ch_cnt = 0;

	while (*wstr1_ptr == *wstr2_ptr)
	{
		if (*wstr1_ptr == L'\0')
			return TRUE;
		wstr1_ptr += 2;
		wstr2_ptr += 2;
		ch_cnt += 1;
		if (ch_cnt > max_count)
			return FALSE;
	}
	return (*wstr2_ptr == L'\0');
}
