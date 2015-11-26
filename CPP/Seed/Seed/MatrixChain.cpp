#include <iostream>
#include <vector>
using namespace std ;

class matrix_chain
{
public:
    matrix_chain(const vector<int> & c) {
        cols = c ;
        count = cols.size () ;
        mc.resize (count) ;
        s.resize (count) ;
        for (vector<int>::size_type i = 0; i < count; ++ i) {
            mc[i].resize (count) ;
            s[i].resize (count) ;
        }
        for (vector<int>::size_type i = 0; i < count; ++ i) {
            for (int j = 0; j < count; ++ j) {
                mc[i][j] = 0 ;
                s[i][j] = 0 ;
            }
        }
    }

    // 使用备忘录方法计算
    void lookup_chain () {
        __lookup_chain (1, count - 1) ;
        min_count = mc[1][count - 1] ;
        cout << "min_multi_count = "<< min_count << endl ;
        // 输出最优计算次序
        __trackback (1, count - 1) ;
    }

    // 使用普通方法进行计算
    void calculate () {
        int n = count - 1; // 矩阵的个数
        // r 表示每次宽度
        // i,j表示从从矩阵i到矩阵j
        // k 表示切割位置
        for (int r = 2; r <= n; ++ r) {
            for (int i = 1; i <= n - r + 1; ++ i) {
                int j = i + r - 1 ;
                // 从矩阵i到矩阵j连乘，从i的位置切割，前半部分为0
                mc[i][j] = mc[i+1][j] + cols[i-1] * cols[i] * cols[j] ;
                s[i][j] = i ;
                for (int k = i + 1; k < j; ++ k) {
                    int temp = mc[i][k] + mc[k + 1][j] + 
                        cols[i-1] * cols[k] * cols[j] ;
                    if (temp < mc[i][j]) {
                        mc[i][j] = temp ;
                        s[i][j] = k ;
                    }
                } // for k
            } // for i
        } // for r
        min_count = mc[1][n] ;
        cout << "min_multi_count = "<< min_count << endl ;
        // 输出最优计算次序
        __trackback (1, n) ;

    }

private:
    int __lookup_chain (int i, int j) {
        // 该最优解已求出，直接返回
        if (mc[i][j] > 0) {
            return mc[i][j] ;
        }
        if (i == j) {
            return 0 ;    // 不需要计算，直接返回
        }

        // 下面两行计算从i到j按照顺序计算的情况
        int u = __lookup_chain (i, i) + __lookup_chain (i + 1, j) 
            + cols[i-1] * cols[i] * cols[j] ;
        s[i][j] = i ;
        for (int k = i + 1; k < j; ++ k) {
            int temp = __lookup_chain(i, k) + __lookup_chain(k + 1, j) 
                + cols[i - 1] * cols[k] * cols[j] ;
            if (temp < u) {
                u = temp ;
                s[i][j] = k ;
            }
        }
        mc[i][j] = u ;
        return u ;
    } 

    void __trackback (int i, int j) {
        if (i == j) { 
            return ; 
        }
        __trackback (i, s[i][j]) ;
        __trackback (s[i][j] + 1, j) ;
        cout <<i << "," << s[i][j] << " " << s[i][j] + 1 << "," << j << endl; 
    }

private:
    vector<int>    cols;    // 列数
    int            count;    // 矩阵个数  + 1
    vector<vector<int>>    mc;    // 从第i个矩阵乘到第j个矩阵最小数乘次数
    vector<vector<int>>    s;    // 最小数乘的切分位置
    int            min_count;        // 最小数乘次数
};

int fun1() 
{
    // 初始化
    const int MATRIX_COUNT = 6;
    vector<int> c(MATRIX_COUNT + 1);
    c[0] = 30 ;
    c[1] = 35 ;
    c[2] = 15 ;
    c[3] = 5 ;
    c[4] = 10 ;
    c[5] = 20 ;
    c[6] = 25 ;

    matrix_chain mc(c);
    // mc.calculate () ;
    mc.lookup_chain();
    return 0 ;
}
