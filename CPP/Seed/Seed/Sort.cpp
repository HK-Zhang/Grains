#include "Sort.h"
using namespace std;


int bubbleSort(int a[],int n)
{
	for(int i=0;i<n;++i)
	{
		for(int j=n-1-i;j>i;--j)
		{
			if(a[j]>a[j-1])
			{
				int temp = a[j];
				a[j]=a[j-1];
				a[j-1]=temp;
			}
			if(a[j]<a[n-1-i])
			{
				int temp = a[j];
				a[j]=a[n-1-i];
				a[n-1-i]=temp;
			}
		}
	}
	return 0;
}

int bubbleSortSimple(int a[],int n)
{
	for(int i=0;i<n;++i)
	{
		for(int j=n-1;j>i;--j)
		{
			if(a[j]>a[j-1])
			{
				int temp = a[j];
				a[j]=a[j-1];
				a[j-1]=temp;
			}
		}
	}
	return 0;
}

int generateRandomVector(vector<int>& c)
{
	//vector<int> c(10);
	srand(100);
	for(vector<int>::size_type i=0;i<c.size();++i)
	{
		c[i]=random(100);
		//printf("%d\n",c[i]);
	}
              
	return 0;
}

int headToTail(int target,vector<int>::iterator& head,vector<int>::iterator& tail)
{
	while(target>*head && head!=tail)
	{
		++head;
	}

	if(head!=tail)
	{
		*tail=*head;
		--tail;
	}

	return 0;
}

int tailToHead(int target,vector<int>::iterator& head,vector<int>::iterator& tail)
{
	while(target<*tail && head!=tail)
	{
		--tail;
	}

	if(head!=tail)
	{
		*head=*tail;
		++head;
	}

	return 0;
}

int quickSort(vector<int>::iterator head,vector<int>::iterator tail)
{
	//printf("%d\n",tail-head);
	vector<int>::iterator tHead=head;
	vector<int>::iterator tTail=tail;
	int temp=*head;

	while(head!=tail){

		tailToHead(temp,head,tail);

		if(head!=tail)
		{
			headToTail(temp,head,tail);
		}

	}

	if(head==tail)
	{
		*head=temp;
	}

	//printf("%d",head-tHead);

	if(tail-tHead>1)
	{
		quickSort(tHead,--tail);
	}

	if(tTail-head>1)
	{
		quickSort(++head,tTail);
	}


	return 0;
}

int sortTest()
{
	const int N=30;

	vector<int> c(N);
	generateRandomVector(c);
	//for(int i=0;i<N;++i)
	//{
	//	printf("%d\n",c[i]);
	//}

	for(vector<int>::iterator iter=c.begin();iter!=c.end();++iter)
	{
		printf("%d ",*iter);
	}

	printf("\n");

	quickSort(c.begin(),--c.end());

	for(vector<int>::iterator iter=c.begin();iter!=c.end();++iter)
	{
		printf("%d ",*iter);
	}

	printf("\n");

	//int a[N]={0,4,2,13,65,21,74,27,98,13};
	////bubbleSort(a,N);
	//bubbleSortSimple(a,N);
	//for (int i=0;i<N;++i)
	//{
	//	cout<<a[i]<<endl;
	//}

	return 0;

}

