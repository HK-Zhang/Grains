#include "InheritanceDemo.h"
using namespace std;

class Base
{
public:
	void foo(int x){cout<<"Base::foo(int)"<<x<<endl;}
	void foo(float x){cout<<"Base::foo(float)"<<x<<endl;}
	virtual void goo(int x){cout<<"Base::goo(int)"<<x<<endl;}

private:

};

class Derived:public Base
{
public:
	virtual void goo(int x){cout<<"Derived::goo(int)"<<x<<endl;};
	void foo(int x){cout<<"Derived::foo(int)"<<x<<endl;}

private:

};

int RunInheritanceDemo()
{
	Derived d;
	Base *pd=&d;
	pd->foo(1);
	pd->foo(2.1f);
	pd->goo(3);
	d.foo(4);

	return 1;
}




