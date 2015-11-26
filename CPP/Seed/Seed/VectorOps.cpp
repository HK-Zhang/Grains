#include <iostream>
#include <stdio.h>
#include <vector>

using namespace std;

int vecTest1()
{
	vector<int> myVect;
	myVect.reserve(100);
	for(int i=0;i<100;i++)
	{
		myVect.push_back(i);
	}
	myVect.resize(102);
	myVect[100]=1;
	myVect[101]=2;

	for(vector<int>::iterator iter=myVect.begin(); iter!=myVect.end();++iter)
		cout<<*iter<<endl;

	return 0;
}

int vecTest2()
{
	vector<int> myVect;
	myVect.push_back(1);
	myVect.push_back(2);
	myVect.push_back(3);
	myVect.push_back(4);
	myVect.reserve(100);
	cout<<myVect.size()<<endl;
	cout<<myVect.capacity()<<endl;
	for(vector<int>::size_type i=0;i<104;++i)
	{
		cout<<myVect[i]<<endl;
	}

	return 0;
}

int vecTest3()
{
	vector<int> myVect;
	myVect.push_back(1);
	myVect.push_back(2);
	myVect.push_back(3);
	myVect.push_back(4);
	myVect.resize(100);
	cout<<myVect.size()<<endl;
	cout<<myVect.capacity()<<endl;
	for(vector<int>::size_type i=0;i<100;++i)
	{
		cout<<myVect[i]<<endl;
	}

	return 0;
}

int vecTest4()
{
	vector<int> myVect;
	myVect.resize(100);
	myVect.push_back(1);
	myVect.push_back(2);
	myVect.push_back(3);
	myVect.push_back(4);
	cout<<myVect.size()<<endl;
	cout<<myVect.capacity()<<endl;
	for(vector<int>::size_type i=0;i<104;++i)
	{
		cout<<myVect[i]<<endl;
	}

	return 0;
}

int freeVec()
{
	vector<int> myVect;
	myVect.push_back(1);
	myVect.push_back(2);
	myVect.push_back(3);
	myVect.push_back(4);
	vector<int>().swap(myVect);

	return 0;
}
