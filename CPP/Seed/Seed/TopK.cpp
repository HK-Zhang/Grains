#include<iostream>
#include<vector>
#include<iterator>
#include<algorithm>

using namespace std;

template<class T>
int linear_time_select(vector<T> &arr,int start,int end,int n)
{
	if(end-start<75)
	{
		sort(arr.begin()+start,arr.begin()+end+1);
		return arr[start+n-1];
	}

	for(int i=0;i<(end-start-4)/5;++i)
	{
		sort(arr.begin()+start+i*5,arr.begin()+start+i*5+5);
		swap (*(arr.begin() + start + 5 * i + 2),*(arr.begin() + start + i));
	}

	// 找到中位数的中位数    
	T median = linear_time_select(arr,start,
		start + (end - start - 4) / 5 - 1,
		(end - start - 4) / 10 + 1);

	int middle = __partition_by_median(arr,start,end,median);
	int distance = middle-start+1;
	if(n<distance)
		return linear_time_select(arr,start,middle,n);
	else
		return linear_time_select(arr,middle + 1,end,n - distance);
}

// 将arr按照值median划分开来，并返回界限的位置
template<class T>
int __partition_by_median(vector<T> &arr,int start,int end,T median)
{
	while (true) {        
		while (true) {            
			if (start == end)                
				return start;            
			else if (arr[start] < median)                
				++ start;            
			else                
				break;        }        
		while (true) {            
			if (start == end)                
				return end;            
			else if (arr[end] > median) {                
				-- end;            
			}            
			else                
				break;        
		}        
		swap(arr[start],arr[end]);    
	}
}

int GetKth()
{
	vector<int> arr;    
	const int c = 2000;    
	for (int i = 0;i < c; ++ i) {        
		arr.push_back(i);    }    
	// 随机排列    
	random_shuffle(arr.begin(),arr.end());    
	for (int i = 1; i < c+1; ++ i) {        
		cout << "find the " << i << " element,position is "           
			<< linear_time_select(arr,0,c-1,i) << endl;    
	}    return 0;
}
