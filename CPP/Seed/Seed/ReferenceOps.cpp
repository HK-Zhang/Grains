#include <iostream>
#include <string>
using namespace std ;

class cA
{
public:
	int A;
};

int refOpsTest()
{
	cA objA;
	objA.A=1;
	cA &ra=objA;
	cA objB;
	objB.A=2;
	cout<<&ra<<" "<<&objA<<" "<<ra.A<<" "<<objA.A<<endl;
	ra=objB;
	cout<<&ra<<" "<<&objA<<" "<<&objB<<" "<<ra.A<<" "<<objA.A<<endl;
	objB.A=3;
	cout<<&ra<<" "<<&objA<<" "<<&objB<<" "<<ra.A<<" "<<objA.A<<" "<<objB.A<<endl;
	return 0;
}
