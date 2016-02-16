#ifndef TRAVELER_H_
#define TRAVELER_H_
#include <iostream>
#include <vector>
#include <queue>
#include <limits>
#include <iterator>

using namespace std;
class heap_node
{
public:
	heap_node(float lc,float cc,float rc,int s,const vector<int> p)
		:lower_cost(lc),current_cost(cc),remainder_cost(rc),size(s)
	{
		path = p;
	}

	friend
	bool operator< (const heap_node& rhs, const heap_node& lhs)
	{
		return rhs.lower_cost > lhs.lower_cost ;
	}

public:
	float lower_cost;
	float current_cost;
	float remainder_cost;
	int size;
	vector<int> path;

};

class BBTSP
{
public:
	BBTSP(const vector<vector<float> >& g)
	{
		graph = g;
		node_count = (int)g.size();
		best_p.resize(node_count);
	}

	void bb_TSP()
	{
		int n = node_count;
		min_heap mh;
		vector<float> min_out(node_count);
		float min_sum = 0.0f;

		for(int i=0;i<node_count;++i)
		{
			float min = MAX_VALUE;
			for(int j=0;j<node_count;++j)
			{
				if (graph[i][j] != NO_EDGE_VALUE && graph[i][j] < min) {
					min = graph[i][j] ;
				}
			}

			if (min == MAX_VALUE) {
				cerr << " No cycle !" << endl;
				return ;
			}

			min_out[i] = min ;
			min_sum += min ;
		}

		for (int i = 0; i < node_count ; ++ i) {
			cout << "Node" << i << "'s min out cost: " << min_out[i] << endl ; 
		}

		cout << "total cost: " << min_sum << endl << endl ;

		vector<int>	path(n) ;
		for (int i = 0; i < n; ++ i) {
			path[i] = i;
		}

		heap_node hn(0, 0, min_sum, 0, path);
		float	best_c = MAX_VALUE ;

		while (hn.size < n - 1) {
			path = hn.path ;
			cout << "path: " ;
			copy (path.begin(), path.end(), ostream_iterator<int>(cout," ")) ;
			cout << endl ;

			if (hn.size == n - 2) {
				if (graph[path[n-2]][path[n-1]] != NO_EDGE_VALUE && 
					graph[path[n-1]][1] != NO_EDGE_VALUE &&
					hn.current_cost + graph[path[n-2]][path[n-1]] + 
					graph[path[n-1]][1] < best_c ) {
					best_c = hn.current_cost + graph[path[n-2]][path[n-1]] + 
						graph[path[n-1]][1] ;
					hn.current_cost = best_c ;
					hn.lower_cost = best_c ;
					hn.size ++ ;
					mh.push (hn) ;
				}
			}
			else {
				for (int i = hn.size + 1; i < n; ++ i) {
					if (graph[path[hn.size]][path[i]] != NO_EDGE_VALUE) {
						float cc = hn.current_cost + graph[path[hn.size]][path[i]] ;
						float rcost = hn.remainder_cost - min_out[path[hn.size]] ;
						float b = cc + rcost ;
						if (b < best_c) {
							vector<int>	p(n) ;
							for (int j = 0; j < n; ++ j) {
								p[j] = path[j] ;
							}

							//copy (p.begin(), p.end(), ostream_iterator<int> (cout, " ")) ;
							//cout << ", " ;

							p[hn.size + 1] = path[i] ;
							p[i] = path[hn.size + 1] ;	

							//copy (p.begin(), p.end(), ostream_iterator<int> (cout, " ")) ;
							//cout << endl; 

							heap_node in(b, cc, rcost, hn.size + 1, p) ;
							mh.push (in) ;
						}
					}
				}

			}

			hn = mh.top () ;
			mh.pop () ;
		}
		best_cost = best_c ;
		for (int i = 0; i < node_count; ++ i) {
			best_p[i] = path[i] ;
		}
		copy (best_p.begin(), best_p.end(), ostream_iterator<int> (cout, " ")) ;
		cout << endl ;
		cout << "best cost : " << best_cost << endl ; 
	}

public:
	static float MAX_VALUE;
	static float NO_EDGE_VALUE;
	typedef priority_queue<heap_node> min_heap;

private:
	vector<vector<float> > graph;
	int node_count;
	vector<int> best_p;
	float best_cost ;

};

int RunTraveler();

#endif
