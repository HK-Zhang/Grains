#include <iostream>
#include <stdio.h>
#include<bitset>

using namespace::std;

int value[6][6]={ 
	{0,0,0,0,0,0}, 
	{0,0,10,30,80,125}, 
	{0,-10,0,20,70,125}, 
	{0,-30,-20,0,50,95}, 
	{0,-80,-70,-50,0,45}, 
	{0,-125,-125,-95,-45,0}};

int dim = 5;

bitset<6> tansMat[6];

int compCost(int i,int j)
{
	return 0;
}

int calTransMatrix()
{
	for(int i=0;i<dim-1;i++)
	{
		for(int j=i+1;j<dim;j++)
		{
			compCost(i,j);
		}
	}
	cout<<value[1][5]<<endl;
	cout<<tansMat[1][5]<<endl;
	return 0;
}
