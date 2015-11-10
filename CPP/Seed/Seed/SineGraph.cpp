#include <Windows.h>
#include <stdlib.h>
#include <math.h>


const double SPLIT = 0.01;
const int COUNT = 200;
const double PI = 3.14159265;
const int INTERVAL = 300;

DWORD busySpan[COUNT];
DWORD idleSpan[COUNT];

void setupSpan()
{
	int half = INTERVAL/2;
	double radian = 0.0;

	for(int i=0;i<COUNT;i++)
	{
		busySpan[i]=(DWORD)(half+(sin(PI*radian))*half);
		idleSpan[i]=INTERVAL-busySpan[i];
		radian += SPLIT;
	}
}

int sineGraph()
{
	setupSpan();
	DWORD startTime = 0;
	int j =0;
	while (true)
	{
		j=j/COUNT;
		startTime = GetTickCount();
		while ((GetTickCount()-startTime)<=busySpan[j])
			;
		Sleep(idleSpan[j]);
		j++;
	}
	return 0;
}

void showSine(void *para)
{
	sineGraph();
}

int mutipleSineGraph()
{
	SYSTEM_INFO info;
	GetSystemInfo(&info);
	int nNum = info.dwNumberOfProcessors;

	DWORD dwThreadId;
	HANDLE hThread;
	for(int i=0;i<nNum;i++)
	{
		hThread = CreateThread(NULL,0,(LPTHREAD_START_ROUTINE)showSine,NULL,0,&dwThreadId);
		SetThreadAffinityMask(hThread,(1<<i));
	}

	WaitForSingleObject(hThread,INFINITE);
	return 0;

}
