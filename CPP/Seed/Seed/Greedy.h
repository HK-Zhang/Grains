#ifndef GREEDY_H_
#define GREEDY_H_
#include<vector>
#include<iostream>
#include<algorithm>
#include<iterator>

using namespace std;


struct ActivityTime
{
	int m_nstart;
	int m_nend;

	ActivityTime(int n_start,int n_end)
		:m_nstart(n_start),m_nend(n_end){}

	ActivityTime()
		:m_nstart(0),m_nend(0){}

	friend
	bool operator <(const ActivityTime &lth, const ActivityTime &rth)
	{
		return lth.m_nend<rth.m_nend;
	}

};

class ActivityArrange
{
public:
	ActivityArrange(const vector<ActivityTime> &vTimelist)
	{
		m_vTimeList = vTimelist;
		m_ncount = m_vTimeList.size();
		m_bvSelectFlag.resize(m_ncount,false);
	}

	void greedySelector()
	{
		__sortTime();
		 m_bvSelectFlag[0] = true ;  
		 
		 int j=0;

		 for(int i=1; i<m_ncount;++i)
		 {
			  if (m_vTimeList[i].m_nstart > m_vTimeList[j].m_nend) {
                m_bvSelectFlag[i] = true ;
                j = i ;
            }
		 }

		copy (m_bvSelectFlag.begin(), m_bvSelectFlag.end() ,ostream_iterator<bool> (cout, " "));
        cout << endl ;
	}

private:
	void __sortTime()
	{
		sort(m_vTimeList.begin(),m_vTimeList.end());

		for(vector<ActivityTime>::iterator ice = m_vTimeList.begin(); ice!=m_vTimeList.end();++ice)
		{
			cout << ice->m_nstart << ", "<< ice ->m_nend << endl;
		}
	}

private:
	vector<ActivityTime> m_vTimeList;
	vector<bool> m_bvSelectFlag;
	int m_ncount;

};

int GreedyDemo();


#endif