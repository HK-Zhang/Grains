#include <iostream>
#include <stdio.h>

int calInx(int i,int pace,int len)
{
	int t=(i+pace)%len;
	return t;
	//if(t<len)
	//{
	//	return t;
	//}
	//else
	//{
	//	return t-len;
	//}
}

int rotateArray(char* source,int k,int l)
{
	//char source[11]="abcdefhigk";


	//int k=3;
	//int l=sizeof(source)-1;

	char b=source[0];
	int kb=0;
	int kn=(k)%l;
	int m=(l%k == 0 ? k : 1);

	for(int i=0;i<m;i++)
	{
		b=source[i];
		kb=i;
		kn=(k+i)%l;

		while(kn!=l-k+i)
		{
			source[kb]=source[kn];
			kb=kn;
			kn=(kb+k)%l;
		}

		source[kb]=source[kn];
		source[kn]=b;
	}



	//while(kn!=l-k)
	//{
	//	source[kb]=source[kn];
	//	kb=kn;
	//	kn=(kb+k)%l;
	//}

	//source[kb]=source[kn];
	//source[kn]=b;



	//m=calInx(0,3,l);
	//char c[20];
	//sprintf(c,"%d",m);
	//printf(c);

	return 0;
}
