#include "ExternTest1.h"

using namespace std;

void externTestFun2()
{
	cout <<"fun2 g_str "<< g_str << endl; 
	g_str[0]='b';
	cout <<"fun2 g_str "<< g_str << endl; 
	cout<<"fun2 s_str "<<s_str<<endl;
	//cout << h_str << endl; 
}
