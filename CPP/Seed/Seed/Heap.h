#include <vector>
#include <iostream>
#include <algorithm>
#ifndef _HEAP_H
#define _HEAP_H

using namespace std;

template<typename Type>
class Heap
{
public:
	Heap(const vector<Type>& a_array)
	{
		m_array.assign(a_array.begin(),a_array.end());
	}


	template<typename Compare>
	void Sort(Compare comp);

	void PrintArray(const vector<Type>& a_array)
	{
		for(int i = 0;i<a_array.size();++i)
		{
			cout<<a_array[i]<<" ";
		}
		cout<<endl;
	}

private:
	vector<Type> m_array;

	template<typename Compare>
	void creatHeap(Compare comp);

	template<typename Compare>
	void downElement(int a_elem, Compare comp);

};

template<typename Type>
template<typename Compare>
void Heap<Type>::Sort(Compare comp)
{
	//PrintArray(m_array);
    creatHeap(comp);
    vector<Type> array;
    for (int i = m_array.size() - 1; i >= 0; --i)
    {
        array.push_back(m_array[0]); 
        swap(m_array[0], m_array[i]); 
        m_array.pop_back(); 
        downElement(0,comp); 
    }
    //PrintArray(array);
    m_array.assign(array.begin(),array.end());
	PrintArray(m_array);
}

template<typename Type>
template<typename Compare>
void Heap<Type>::creatHeap(Compare comp)
{
	for (int i=m_array.size()/2-1; i>=0; i--)
	{
		downElement(i,comp);
	}
}

template<typename Type>
template<typename Compare>
void Heap<Type>::downElement(int a_elem,Compare comp)
{
	int min;
	int index=a_elem;

	while(2*index+1<m_array.size())
	{
		min = index*2+1;

		if (index*2+2 < m_array.size())
        {
            if (comp(m_array[index*2+2],m_array[min]))
            {
                min = index*2+2;
            }
        }

		if (comp(m_array[index],m_array[min]))
        {
            break;
        }
        else
        {
            swap(m_array[min],m_array[index]);
            index = min;
        }
	}
}

#endif
