#include "FindDemo.h"
using namespace std;

template<class T>
int binary_search(T array[],const T& value,int left,int right )
{

	while(right>=left)
	{
		int m=(left+right)/2;

		if (value == array[m])
            return m;

        if (value < array[m])
            right = m - 1;
        else
            left = m + 1;

	}
	return -1;
}

int findDemo()
{

	int array[]={1,2,3,4,5,6,7,8,9,10};
	cout << "1 in array position: " << binary_search(array,1,0,9) << endl;
	return 0;

}
