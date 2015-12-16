#include "ExternTest1.h"

using namespace std;

char g_str[]="123456";
void externTestFun1()
{
	cout<<"fun1 g_str "<<g_str<<endl;
	cout<<"fun1 s_str "<<s_str<<endl;
	s_str[0]='a';
	cout<<"fun1 s_str "<<s_str<<endl;
	//cout << h_str << endl; 
}
