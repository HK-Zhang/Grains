#include <iostream>
#include <stdio.h>

using namespace std;

int pointTrial()
{
	char *p[5];
	char (*p2)[5];

	cout << sizeof(p)<< sizeof(*p) << endl;
	cout << sizeof(p2)<< sizeof(*p2) << endl;


	return 0;
}
