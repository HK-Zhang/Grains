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

char *GetString(void)
{
	char p[] = "hello world";
	cout<<&p<<" "<<p<<endl;
	return p; // 编译器将提出警告
	
}

void pointTrial3(void)
{
	char *str = NULL;
	str = GetString(); // str 的内容是垃圾
	cout<< str << endl;
}


int pointTrial2()
{
	int a[5]={1,2,3,4,5};
	int *p=a;
	cout<<&p<<" "<<p<<" "<<&a<<" "<<a<<endl;
	return 0;
}

int pointTrial4()
{
	int a=0;
	int *p=&a;
	cout<<&p<<" "<<p<<" "<<&a<<" "<<a<<" "<<*p<<endl;
	int **p1=&p;
	cout<<&p1<<" "<<p1<<" "<<*p1<<" "<<**p1<<endl;
	//int *p2=p1;
	return 0;
}
