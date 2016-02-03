#include "MaxLoading.h"

using namespace std;

int runMaxloading()
{
	 const int capacity = 20 ;    
	 vector<int> weight ;    
	 weight.push_back (10);    
	 weight.push_back (8);    
	 weight.push_back (1);    
	 weight.push_back (2);    
	 weight.push_back (3);    
	 load_PQBAB l (weight, capacity) ;    
	 l.max_loading ();    
	 loadBAB lb (weight, capacity) ;    
	 lb.queue_BAB () ;    
	 cout << lb.get_best_w() << endl ; 

	return 0;
}
