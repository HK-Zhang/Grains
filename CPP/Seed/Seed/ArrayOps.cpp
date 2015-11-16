#include <iostream>
#include <stdio.h>

int reverseArray(char* source,int l)
{
	char temp;

	for(int i=0;i<l/2;i++)
	{
		temp = source[i];
		source[i] = source[l-i-1];
		source[l-i-1] = temp;
	}

	return 0;
}

int rotateArray2(char* source,int k,int l)
{
	reverseArray(source,k);
	reverseArray(&source[k],l-k);
	reverseArray(source,l);
	return 0;
}

int rotateArray(char* source,int k,int l)
{

	char b;
	int kb;
	int kn;

	int m=(l%k == 0 ? k : 1);

	//if array's length can be divided by k then it is need to loop k round. otherwise loop 1 round is enough.
	for(int i=0;i<m;i++)
	{
		b=source[i];
		kb=i;
		kn=(k+i)%l;//caculate the index of value which will fullfill the current slot located at index i.

		//ended when next slot is the one which the first slot to fullfill.
		while(kn!=l-k+i)
		{
			source[kb]=source[kn];
			kb=kn;
			kn=(kb+k)%l;
		}

		source[kb]=source[kn];
		source[kn]=b;
	}

	return 0;
}

int maxSerial(int* s,int l)
{
	int f=0;
	int maxL=1;
	int itv=1;
	int tl=1;

	for(int i=0;i<l;i++)
	{
		if(itv==s[i]-s[i+1])
		{
			tl=tl+1;

		}
	}


	return 0;
}
