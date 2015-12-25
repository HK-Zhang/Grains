#include "Main.h"
using namespace std;

void helloWorld()
{
	std::cout<<"Hello World!!!"<<std::endl;
	printf(PRINT_STR);
}



void addTwoNumber()
{
	std::cout << "Enter two numbers:" << std::endl;
	int v1, v2;
	std::cin >> v1 >> v2;
	std::cout << "The sum of " << v1 << " and " << v2 << " is " << v1 + v2 << std::endl;
}

void moveBit()
{
	unsigned i,j;

	unsigned short short11 = 1024;
	std::bitset<16> bitset11(short11);
	std::cout << bitset11 << std::endl;  

	i=1;
	std::bitset<32> bitset1(i);
	std::cout << bitset1 << std::endl;  

	j=1<<i;
	bitset<32> bitset2(j);
	cout << bitset2 << endl;  

	j=i>>1;
	bitset<32> bitset3(j);
	cout << bitset3 << endl;  

	std::cout<<j<<std::endl;
}

void forTest()
{
	for(;;)
	{
		for(int i=0;i<9600000;i++)
			_sleep(10);
	}
}

void pointTest()
{
	int n = 5;
	int *pn = &n;
	int **ppn=&pn;

	cout<< "Value of n:\n"
		<<"direct value: "<<n<<endl
		<<"indirect value: "<<*pn<<endl
		<<"doubly indirect value: "<<**ppn<<endl
		<<"address of n: "<<pn<<endl
		<<"address of n via indirection:"<<*ppn<<endl;
}

void rotateArrayTest()
{
	char source[12]="abcdefhigkl";
	printf(source);
	printf("\n");
	//rotateArray(source,3,11);
	//reverseArray(source,11);
	rotateArray2(source,3,11);
	printf(source);
	//delete []source;
}

int main()
{
	//forTest();
	int a=0;
	//helloWorld();
	//moveBit();
	//pointTest();
	//addTwoNumber();
	//sineGraph();
	//mutipleSineGraph();
	//rotateArrayTest();
	//arrayTrial();

	//pointTrial();

	//calTransMatrix();
	//freeVec();
	//fun1();
	//longCommonSequence();
	//maxSubSumFun();
	//polyGameFun();
	//refOpsTest();
	//pointTrial3();
	//sortTest();
	//pointTrial4();
	//externTestFun1();
	//externTestFun2();
	//externTestFun1();
	constructorDemo();

	std::cin>>a;
	return 0;
}

