#ifndef QUEEN_H_
#define QUEEN_H_
class Queen
{
public:

	friend int nQueen(int);
private:
	int n;
	int *x;
	long sum;
	bool place(int k);
	void backTrack(int k);
};

int QueenRun();
#endif
