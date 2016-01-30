/* 主题：最大子段和
* 作者：chinazhangjie
* 邮箱：chinajiezhang@gmail.com
* 开发语言：C++
* 开发环境：Microsoft Virsual Studio 2008
* 时间: 2010.11.15
*/

#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

class MaxSubSum 
{
public:
    MaxSubSum (const vector<int>& intArr) 
    {
        m_vIntArr = intArr ;
        m_nLen = m_vIntArr.size () ;
    }

    // use divide and conquer 
    int use_DAC () 
    {
        m_nMssValue = __use_DAC (0, m_nLen - 1) ;
        return m_nMssValue ;
    }

    // use dynamic programming
    int use_DP () 
    {
        int sum = 0 ;
        int temp = 0 ;

        for (int i = 0; i < m_nLen; ++ i) {
            if (temp > 0) {
                temp += m_vIntArr[i] ;
            }
            else {
                temp = m_vIntArr[i] ;
            }
            if (temp > sum) {
                sum = temp ;
            }
        }
        m_nMssValue = sum ;
        return sum ;
    }

private:
    int __use_DAC (int left, int right) 
    {
        // cout << left << "," << right << endl ;
        if (left == right) {
            return (m_vIntArr[left] > 0 ? m_vIntArr[left] : 0) ;
        }

        // 左边区域的最大子段和
        int leftSum = __use_DAC (left, (left + right) / 2) ;
        // 右边区域的最大子段和
        int rightSum = __use_DAC ((left + right) / 2 + 1, right) ;
        // 中间区域的最大子段和
        int sum1 = 0 ;
        int max1 = 0 ;
        int sum2 = 0 ;
        int max2 = 0 ;
        for (int i = (left + right) / 2; i >= left; -- i) {
            sum1 += m_vIntArr[i] ;
            if (sum1 > max1) {
                max1 = sum1 ;
            }
        }
        for (int i = (left + right) / 2 + 1; i <= right; ++ i) {
            sum2 += m_vIntArr[i] ;
            if (sum2 > max2) {
                max2 = sum2 ;
            }
        }
        int max0 = max1 + max2 ;
        max0 = (max0 > 0 ? max0 : 0) ;
        // cout << max0 << ", " << leftSum << ", " << rightSum << endl ;
		return max(max0, max(leftSum, rightSum));
    }

private:
    vector<int>    m_vIntArr ;    // 整形序列
    int            m_nLen ;    // 序列长度
    int            m_nMssValue;// 最大子段和
} ;

int maxSubSumFun()
{
    vector<int> vArr ;
    vArr.push_back (-2) ;
    vArr.push_back (11) ;
    vArr.push_back (-4) ;
    vArr.push_back (13) ;
    vArr.push_back (-5) ;
    vArr.push_back (-2) ;

    MaxSubSum mss (vArr) ;
    cout << mss.use_DP () << endl ;
    return 0 ;
}
