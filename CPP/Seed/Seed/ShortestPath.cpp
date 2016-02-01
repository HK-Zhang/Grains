#include "ShortestPath.h"

int runShortestPath()
{
	const int size =11;
	vector<vector<int> > graph(size);

	for(int i=0;i<size;++i)
	{
		graph[i].resize(size);
	}

	for(int i=0;i<size;++i)
	{
		for(int j=0;j<size;++j)
		{
			cout<<i<<" "<<j<<endl;
			graph[i][j] = -1;
		}
	}

	graph[0][1] = 2;    
	graph[0][2] = 3;    
	graph[0][3] = 4;    
	graph[1][2] = 3;    
	graph[1][5] = 2;    
	graph[1][4] = 7;    
	graph[2][5] = 9;    
	graph[2][6] = 2;    
	graph[3][6] = 2;    
	graph[4][7] = 3;    
	graph[4][8] = 3;    
	graph[5][6] = 1;    
	graph[5][8] = 3;    
	graph[6][9] = 1;    
	graph[6][8] = 5;    
	graph[7][10] = 3;    
	graph[8][10] = 2;    
	graph[9][8] = 2;    
	graph[9][10] = 2;

	 ss_shortest_path ssp (graph, 10);
	 ssp.shortest_paths();
	 ssp.print_spath();

	 return 1;
}
