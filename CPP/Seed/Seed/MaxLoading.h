#ifndef MAX_LOADING_H_
#define MAX_LOADING_H_
#include <iostream>
#include <vector>
#include <queue>
#include <numeric>
#include <iterator>

using namespace std;

int runMaxloading();

class BB_node
{
public:
	BB_node(BB_node* par, bool lc)
	{
		parent = par;
		left_child = lc;
	}

public:
	BB_node* parent;
	bool left_child;
};

class head_node
{
public:
	head_node(BB_node* node,int uw,int lev)
	{
		live_node=node;
		upper_weight=uw;
		level = lev;
	}

	friend
	bool operator<(const head_node& lth,const head_node& rth)
	{
		return lth.upper_weight<rth.upper_weight;
	}

	friend
	bool operator>(const head_node& lth,const head_node& rth)
	{
		return lth.upper_weight>rth.upper_weight;
	}

public:
	BB_node* live_node;
	int upper_weight;
	int level;

};

class loadBAB
{
public:
	loadBAB(const vector<int>& w,int c)
		:weight(w),capacity(c),c_count(w.size()),best_w(0){}

	int get_best_w() const
	{
		return best_w;
	}

	int queue_BAB()
	{
		live_node_q.push(-1);
		int i=0;
		int cw=0;

		while (true)
		{
			if(cw+weight[i]<=capacity)
			{
				__en_queue(cw+weight[i],i);

				if ((cw + weight[i]) > best_w) {
					best_w = cw + weight[i];
				}
			}

			int best_rest = accumulate(weight.begin()+i+1,weight.end(),0);

			if (best_rest + cw > best_w) 
			{                
				__en_queue(cw, i);
			}

			cw=live_node_q.front();
			live_node_q.pop();

			if(cw==-1)
			{
				if(live_node_q.empty())
				{
					return best_w;
				}

				live_node_q.push(-1);
				cw=live_node_q.front();
				live_node_q.pop();
				++i;
			}

		}

		return best_w;
	}

private:
	void __en_queue(int cw,int i)
	{
		if(i>=c_count-1)
		{
			if(cw>best_w)
			{
				best_w=cw;
			}
		}
		else
		{
			live_node_q.push(cw);
		}
	}

private:
	vector<int> weight;
	queue<int> live_node_q;
	int c_count;
	int capacity;
	int best_w;
};


class load_PQBAB
{
public:
	load_PQBAB(const vector<int>& w,int c)
		:weight(w),capacity(c),c_count(static_cast<int>(w.size())){};

	void max_loading()
	{
		BB_node* pbn = NULL;
		int i=0;
		int ew=0;
		vector<int> r(c_count,0);

		for (int j = c_count - 2;  j >= 0; --j) {
			r[j] = r[j + 1] + weight[j + 1] ;        
		}

		while (i!=c_count)
		{
			if (ew + weight[i] <= capacity) {
				__add_live_node (ew + weight[i] + r[i], i + 1, pbn, true) ;
			}

			__add_live_node (ew + r[i], i + 1, pbn, false) ;

			while (pbn != NULL) {                
				BB_node *p = pbn ;                
				pbn = pbn->parent ;                
				delete p ;            
			}

			head_node node = pri_queue.top () ;            
			pri_queue.pop ();            
			// cout << node.upper_weight <<endl;            
			i = node.level ;            
			pbn = node.live_node ;            
			ew = node.upper_weight - r[i - 1] ;        
		}

		while (pri_queue.size() != 0) {            
			head_node node = pri_queue.top () ;            
			pri_queue.pop () ;            
			while (node.live_node != NULL) {                
				BB_node* temp = node.live_node ;                
				node.live_node = node.live_node->parent ;                
				delete temp ;             
			}        
		}    

		cout << "best capacity: " << ew << endl ;        
		cout << "path: " ;        

		vector<bool> temp_path ;        
		while (pbn != NULL) {            
			temp_path.push_back (pbn->left_child) ;            
			BB_node *temp = pbn ;            
			pbn = pbn->parent ;            
			delete temp ;         
		}  

		copy (temp_path.rbegin(), temp_path.rend(), ostream_iterator<bool>(cout, " "));        
		cout << endl ; 
	}

private:
	void __add_live_node (int uw, int lev, BB_node* par, bool lc) { 
		BB_node *first = NULL;
		BB_node *end = NULL;
		while (par != NULL)
		{
			BB_node *p = new BB_node(NULL,par->left_child);

			if(first==NULL)
			{
				first=p;
				end=p;
			}
			else
			{
				end->parent = p;
				end = end->parent;
			}

			par=par->parent;
		}

		BB_node* p = new BB_node (first, lc) ;        
		pri_queue.push (head_node (p, uw, lev)) ;
	}

private:
	vector<int> weight;
	int capacity; 
	int c_count;
	priority_queue<head_node> pri_queue;
};


#endif
