#include"Greedy.h"

int GreedyDemo()
{
	 vector<ActivityTime> vActiTimeList ;
    vActiTimeList.push_back (ActivityTime(1, 4)) ;
    vActiTimeList.push_back (ActivityTime(3, 5)) ;
    vActiTimeList.push_back (ActivityTime(0, 6)) ;
    vActiTimeList.push_back (ActivityTime(5, 7)) ;
    vActiTimeList.push_back (ActivityTime(3, 8)) ;
    vActiTimeList.push_back (ActivityTime(5, 9)) ;
    vActiTimeList.push_back (ActivityTime(6, 10)) ;
    vActiTimeList.push_back (ActivityTime(8, 11)) ;
    vActiTimeList.push_back (ActivityTime(8, 12)) ;
    vActiTimeList.push_back (ActivityTime(2, 13)) ;
    vActiTimeList.push_back (ActivityTime(12, 14)) ;

    ActivityArrange aa (vActiTimeList) ;
    aa.greedySelector () ;
    return 0 ;
}