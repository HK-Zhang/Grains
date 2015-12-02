/* 主题：多边形游戏
* 作者：chinazhangjie
* 邮箱：chinajiezhang@gmail.com
* 开发语言：C++
* 开发环境：Vicrosoft Visual Studio
* 时间: 2010.11.15
*/

#include <iostream>
#include <vector>
using namespace std ;

struct SegInfo
{
public:
    SegInfo () 
        : m_nMaxValue (0), m_nMinValue(0) 
    {}
    SegInfo (int maxValue, int minValue) 
        : m_nMaxValue (maxValue), m_nMinValue (minValue) 
    {}
public:
    int m_nMaxValue ;
    int m_nMinValue ;
} ;

class PolyGame 
{
public:
    PolyGame (const vector<char>& op, const vector<int>& vertex) 
    {
        m_vcOp = op ;
        m_vnVertex = vertex ;
        m_nCount = m_vcOp.size () ;

        m_vSeg.resize (m_nCount) ;
        for (int i = 0; i < m_nCount; ++ i) {
            m_vSeg[i].resize (m_nCount) ;
        }
    }
    
    int beginCalulate () 
    {
        // 初始边界
        for (int i = 1; i < m_nCount; ++ i) {
            m_vSeg[i][1].m_nMaxValue = m_vnVertex[i] ;
            m_vSeg[i][1].m_nMinValue = m_vnVertex[i] ;
        }

        // i: 起点
        // j: 长度
        // s: 子切分位置
        for (int j = 2; j < m_nCount ; ++ j) {
            for (int i = 1; i < m_nCount; ++ i) {
                for (int s = 1; s < j; ++ s) {
                    SegInfo si = __calMinAndMax(i, s, j) ;
                    if (m_vSeg[i][j].m_nMinValue > si.m_nMinValue) {
                        m_vSeg[i][j].m_nMinValue = si.m_nMinValue ;
                    } 
                    if (m_vSeg[i][j].m_nMaxValue < si.m_nMaxValue) {
                        m_vSeg[i][j].m_nMaxValue = si.m_nMaxValue ;
                    }
                }
            }
        }
        // 找到最大值
        int temp = m_vSeg[1][m_nCount - 1].m_nMaxValue ;
        for (int i = 2; i < m_nCount; ++ i) {
            if (temp < m_vSeg[i][m_nCount - 1].m_nMaxValue) {
                temp = m_vSeg[i][m_nCount - 1].m_nMaxValue ;
            }
        }
        m_nResult = temp ;
        return m_nResult ;
    }

private:
    // 从i开始，长度为j，s为切分位置
    SegInfo __calMinAndMax (int i, int s, int j) 
    {
        int minL = 0 ;
        int maxL = 0 ;
        int minR = 0 ;
        int maxR = 0 ;
        minL = m_vSeg[i][s].m_nMinValue ;
        maxL = m_vSeg[i][s].m_nMaxValue ;
        int r = (i + s - 1) % (m_nCount - 1) + 1 ;
        minR = m_vSeg[r][j - s].m_nMinValue ;
        maxR = m_vSeg[r][j - s].m_nMaxValue ;

        SegInfo si ;
        // 处理加法
        if (m_vcOp[r] == '+') {
            si.m_nMinValue = minL + minR ;
            si.m_nMaxValue = maxL + maxR ;
        }
        else {    // 处理乘法
            vector<int> mm ;
            mm.push_back (minL * minR) ;
            mm.push_back (minL * maxR) ;
            mm.push_back (maxL * minR) ;
            mm.push_back (maxL * maxR) ;
            int min = 0 ;
            int max = 0 ;
            for (vector<int>::iterator ite = mm.begin(); 
                ite != mm.end() ; ++ ite) {
                if (*ite < min) {
                    min = *ite ;
                }
                if (*ite > max) {
                    max = *ite ;
                } 
            }
            si.m_nMinValue = min ;
            si.m_nMaxValue = max ;
        }
        return si ;
     }

private :
    vector<char>    m_vcOp ;    // 运算符(下标从1开始)
    vector<int>        m_vnVertex ;// 顶点值(下标从1开始)
    int                m_nCount ;    // 边的个数
    int                m_nResult ;    // 结果
    vector<vector<SegInfo> > m_vSeg ;// 合并后的信息
} ;

int polyGameFun()
{
    const int cnCount = 5 ;
    vector<char> op (cnCount + 1);
    vector<int>     vertex (cnCount + 1);
    op[1] = '+' ;
    op[2] = '*' ;
    op[3] = '+' ;
    op[4] = '*' ;
    op[5] = '*' ;

    vertex[1] = 10 ;
    vertex[2] = -8 ;
    vertex[3] = 3;
    vertex[4] = -2 ;
    vertex[5] = -1 ;

    PolyGame pg (op, vertex) ;
    cout << pg.beginCalulate () << endl ;

	return 0;
}
