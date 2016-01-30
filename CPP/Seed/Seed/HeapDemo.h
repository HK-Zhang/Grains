#ifndef HEAP_DEOM_H_
#define HEAP_DEOM_H_
#include <vector>
#include <algorithm>
#include <iostream>
#include <queue>
#include <functional>  

using namespace std;

int opsHeap();
int priorityQueueTest();
int opsLargeHeap();
int opsSmallHeap();
int opsGreatHeap();
int opsGreatHeap2();

class PriorityQueue
{
private:
	vector<int> data;

public:
	void push(int i)
	{
		data.push_back(i);
		push_heap(data.begin(),data.end());
	}

	void pop()
	{
		pop_heap(data.begin(),data.end());
		data.pop_back();
	}


	int top()
	{
		return data.front();
	}

	int size()
	{
		return data.size();
	}

	bool empty()
	{
		return data.empty();
	}


};

struct Node
{
	int x, y;
	Node(int a = 0, int b = 0)
		:x(a), y(b){}
};


struct cmp{

	bool operator() (Node a, Node b){

		if (a.x == b.x) return a.y> b.y;



		return a.x> b.x;
	}

};


#endif