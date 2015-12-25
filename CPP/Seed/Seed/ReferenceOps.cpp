#include <iostream>
#include <string>
using namespace std ;

class cA
{
public:
	int A;
};

int constructorTest(cA t)
{
	t.A=2;
	return 0;
}

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

int constructorDemo()
{
	cA a;
	a.A=1;
	cout<<a.A<<endl;
	constructorTest(a);
	cout<<a.A<<endl;
	return 0;
}
