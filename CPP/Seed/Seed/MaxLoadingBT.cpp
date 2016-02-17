#include <vector>
#include <iostream>
#include <iterator>

using namespace std;

void __backtrack (int layers,const int layers_size,int current_w,int& best_w,
				  vector<int>& flag_x,vector<int>& best_x,int remainder_w,const vector<int>& container_w,int total_w)
{
	 if (layers > layers_size - 1)
	 {
		 if (current_w < best_w || best_w == -1) 
		 {
			 copy(flag_x.begin(),flag_x.end(),best_x.begin());
			 best_w = current_w;
		 }

		 return;
	 }

	 remainder_w -= container_w[layers];

	 if (current_w + container_w[layers] <= total_w) 
	 {
		 flag_x[layers] = 1;        
		 current_w += container_w[layers];
		 __backtrack(layers + 1,layers_size,current_w, best_w,flag_x,best_x,remainder_w,container_w, total_w);        
		 current_w -= container_w[layers];
	 }

	 if (current_w + remainder_w > best_w || best_w == -1) 
	 {
		 flag_x[layers] = 0;        
		 __backtrack(layers + 1,layers_size,current_w, best_w,flag_x,best_x,remainder_w,container_w,total_w);
	 }

	 remainder_w += container_w[layers];
}

void loading_backtrack (int total_w, vector<int>& container_w)
{
	int layers_size = container_w.size();   
	int current_w = 0; 
	int remainder_w = total_w; 
	int best_w = -1;
	vector<int> flag_x(layers_size);
	vector<int> best_x(layers_size); 
	__backtrack(0,layers_size,current_w, best_w,flag_x,best_x,remainder_w,container_w,total_w);
	cout << "path : " ;
	copy(best_x.begin(),best_x.end(),ostream_iterator<int>(cout," "));
	cout << endl;    
	cout << "best_w = " << best_w        << "( ";
	for (size_t i = 0;i < best_x.size(); ++ i) 
	{        
		if (best_x[i] == 1) 
		{            
			cout << container_w[i] << " ";        
		}    
	}    
	cout << ")" << endl;
}

int RunMaxLoadingBT()
{
	 const int total_w = 30;    
	 vector<int> container_w;    
	 container_w.push_back(40);    
	 container_w.push_back(1);    
	 container_w.push_back(40);    
	 container_w.push_back(9);    
	 container_w.push_back(1);    
	 container_w.push_back(8);    
	 container_w.push_back(5);    
	 container_w.push_back(50);    
	 container_w.push_back(6);    
	 loading_backtrack(total_w,container_w);    
	 return 0;
}
