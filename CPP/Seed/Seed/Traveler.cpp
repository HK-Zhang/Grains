#include "Traveler.h"

float BBTSP::MAX_VALUE = numeric_limits<float>::max() ;
float BBTSP::NO_EDGE_VALUE = -1.0f ;

int RunTraveler()
{
	const int size = 6 ;
	vector<vector<float> > g(size) ;
	for (int i = 0; i < size; ++ i) {
		g[i].resize (size) ;
	}
	for (int i = 0;i < size; ++ i) {
		g[i][i] = BBTSP::NO_EDGE_VALUE ;
	}
	g[0][1] = 30 ;
	g[0][2] = 6 ;
	g[0][3] = 4 ;
	g[0][4] = 5 ;
	g[0][5] = 6 ;

	g[1][0] = 30 ;
	g[1][2] = 4 ;
	g[1][3] = 5 ;
	g[1][4] = 2 ;
	g[1][5] = 1 ;

	g[2][0] = 6 ;
	g[2][1] = 4 ;
	g[2][3] = 7 ;
	g[2][4] = 8 ;
	g[2][5] = 9 ;

	g[3][0] = 4 ;
	g[3][1] = 5 ;
	g[3][2] = 7 ;
	g[3][4] = 10 ;
	g[3][5] = 20 ;
	
	g[4][0] = 5 ;
	g[4][1] = 2 ;
	g[4][2] = 8 ;
	g[4][3] = 10 ;
	g[4][5] = 3 ;

	g[5][0] = 6 ;
	g[5][1] = 1 ;
	g[5][2] = 9 ;
	g[5][3] = 20 ;
	g[5][4] = 3 ;

	BBTSP	bt(g) ;
	bt.bb_TSP () ;
	return 0;
}
