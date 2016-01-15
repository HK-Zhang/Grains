#include<iostream>
#include "Queen.h"

bool Queen::place(int k)
{
	for(int i=1;i<k;++i)
	{
		if(x[i]==x[k] || abs(i-k)==abs(x[i]-x[k]))
			return false;
	}
	return true;
}

void Queen::backTrack(int k)
{
	if(k>n) ++sum;
	else
	{
		for(int i=1;i<=n;++i)
		{
			x[k]=i;
			if(place(k))backTrack(k+1);
		}
	}
}

int abs(int ab)
{
	return ab>0?ab:-ab;
}

int nQueen(int n)
{
	Queen X;
	X.n=n;
	X.sum=0;
	int *p =new int[n+1];
	for(int i=0;i<=n;++i)
	{
		p[i]=0;
	}
	X.x=p;
	X.backTrack(1);
	delete []p;
	return X.sum;
}

int QueenRun()
{
	printf("%d",nQueen(8));
	return 0;
}
