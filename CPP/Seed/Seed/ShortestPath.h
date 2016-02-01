#ifndef SHORTEST_PATH_H_
#define SHORTEST_PATH_H_
#include <iostream>
#include <vector>
#include <queue>
#include <limits>
#include <iterator>
using namespace std;

int runShortestPath();

struct node_info
{
public:
	node_info(int i,int w)
		:index(i),weight(w){}
	node_info()
		:index(0),weight(0){}
	node_info(const node_info & ni)
		:index(ni.index),weight(ni.weight){}

	friend     
	bool operator < (const node_info& lth,const node_info& rth) {       
		return lth.weight > rth.weight ;
	}

public:
	int index;
	int weight;


};

struct path_info
{
public:
	path_info()
		:front_index(0),weight(numeric_limits<int>::max()){}
public:
	int front_index;
	int weight;
};

class ss_shortest_path
{
public:
	ss_shortest_path(const vector<vector<int> > & g, int end_location)
		:no_edge(-1),end_node(end_location),node_count(g.size()),graph(g)
	{}

	void print_spath() const
	{
		cout<<"min weight:"<<shortest_path<<endl;
		cout<<"path: ";
		copy (s_path_index.rbegin(),s_path_index.rend(),ostream_iterator<int> (cout, " "));
		cout<<endl;
	}

	void shortest_paths()
	{
		vector<path_info> path(node_count);
		priority_queue<node_info,vector<node_info> > min_heap;
		min_heap.push(node_info(0,0));

		while (true)
		{
			node_info top = min_heap.top();
			min_heap.pop();

			if(top.index == end_node)
			{
				break;
			}

			for(int i=0;i<node_count;++i)
			{
				if(graph[top.index][i] != no_edge && top.weight+graph[top.index][i]<path[i].weight)
				{
					min_heap.push(node_info(i,top.weight+graph[top.index][i]));
					path[i].front_index=top.index;
					path[i].weight=top.weight+graph[top.index][i];
				}
			}

			if(min_heap.empty())
			{
				break;
			}
		}

		shortest_path=path[end_node].weight;
		int index = end_node;
		s_path_index.push_back(index);
		while (true)
		{
			index = path[index].front_index;
			s_path_index.push_back(index);
			if(index==0)
			{
				break;
			}
		}
	}

private:
	vector<vector<int> > graph;
	int node_count;
	const int no_edge;
	const int end_node;
	vector<int> s_path_index;
	int shortest_path;
};


#endif
