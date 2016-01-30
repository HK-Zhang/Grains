#include "HeapDemo.h"



int opsHeap()
{
	int myints[] = { 10, 20, 30, 5, 15 };
	//cout << *(myints+4) << endl;
	vector<int> v(myints,myints+5);
	//cout << v.size() << endl;
	vector<int>::iterator it;

	make_heap(v.begin(), v.end());
	cout << "Initial max heap: " << v.front() << endl;

	pop_heap(v.begin(), v.end());
	v.pop_back();
	cout << "max heap after pop: " << v.front() << endl;

	v.push_back(99);
	push_heap(v.begin(), v.end());
	cout << "max heap after push: " << v.front() << endl;

	sort_heap(v.begin(), v.end());

	cout << "final sorted range: " << endl;
	for (unsigned i = 0; i < v.size(); ++i)
		cout << " " << v[i];

	cout << endl;

	return 0;

}

int priorityQueueTest()
{
	PriorityQueue test;
	test.push(2);
	test.push(5);
	test.push(4);
	test.push(3);

	while (!test.empty())
	{
		cout << test.top() << " ";
		test.pop();
	}

	cout << endl;

	return 0;
}

int opsLargeHeap()
{
	priority_queue<int> q;
	for (int i = 0; i < 10; ++i) q.push(rand());

	while (!q.empty())
	{
		cout << q.top() << " ";
		q.pop();
	}

	cout << endl;

	return 0;

}

int opsSmallHeap()
{
	
	priority_queue<int, vector<int>, greater<int> > q;
	for (int i = 0; i < 10; ++i) q.push(rand());

	while (!q.empty())
	{
		cout << q.top() << " ";
		q.pop();
	}

	cout << endl;

	return 0;
}

bool operator< (Node a, Node b)
{
	if (a.x == b.x) return a.y < b.y;

	return a.x < b.x;
}

int opsGreatHeap()
{
	priority_queue<Node> q;
	for (int i = 0; i < 10; ++i) q.push(Node(rand(),rand()));

	while (!q.empty()){

		cout << q.top().x << ' ' << q.top().y << endl;

		q.pop();

	}

	return 0;
}

int opsGreatHeap2()
{
	priority_queue<Node, vector<Node>, cmp> q;

	for (int i = 0; i < 10; ++i) q.push(Node(rand(), rand()));

	while (!q.empty()){

		cout << q.top().x << ' ' << q.top().y << endl;

		q.pop();

	}

	return 0;
}