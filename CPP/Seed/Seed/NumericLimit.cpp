#include<iostream>
#include<limits>
using namespace std;

int numbericLimitRun1()
{
	cout << boolalpha;

	cout << "max(short): " << numeric_limits<short>::max() << endl;
	cout << "min(short): " << numeric_limits<short>::min() << endl;

	cout << "max(int): " << numeric_limits<int>::max() << endl;
	cout << "min(int): " << numeric_limits<int>::min() << endl;

	cout << "max(long): " << numeric_limits<long>::max() << endl;
	cout << "min(long): " << numeric_limits<long>::min() << endl;

	cout << endl;

	cout << "max(float): " << numeric_limits<float>::max() << endl;
	cout << "min(float): " << numeric_limits<float>::min() << endl;

	cout << "max(double): " << numeric_limits<double>::max() << endl;
	cout << "min(double): " << numeric_limits<double>::min() << endl;

	cout << "max(long double): " << numeric_limits<long double>::max() << endl;
	cout << "min(long double): " << numeric_limits<long double>::min() << endl;

	cout << endl;

	cout << "is_signed(char): "
		<< numeric_limits<char>::is_signed << endl;
	cout << "is_specialized(string): "
		<< numeric_limits<string>::is_specialized << endl;
	return 0;
}

int numbericLimitRun2()
{
	cout << boolalpha;
	// 可以表示的最大值  
	cout << "max(float): " << numeric_limits<float>::max() << endl;
	// 可以表示的大于0的最小值，其他类型的实现或与此不同  
	cout << "min(float): " << numeric_limits<float>::min() << endl;
	// 标准库是否为其实现了特化  
	cout << "is_specialized(float): " << numeric_limits<float>::is_specialized << endl;
	// 是否是有符号的，即可以表示正负值  
	cout << "is_signed(float): " << numeric_limits<float>::is_signed << endl;
	// 不否是整形的  
	cout << "is_integer(float): " << numeric_limits<float>::is_integer << endl;
	// 是否是精确表示的  
	cout << "is_exact(float): " << numeric_limits<float>::is_exact << endl;
	// 是否存在大小界限  
	cout << "is_bounded(float): " << numeric_limits<float>::is_bounded << endl;
	// 两个比较大的数相加而不会溢出，生成一个较小的值  
	cout << "is_modulo(float): " << numeric_limits<float>::is_modulo << endl;
	// 是否符合某某标准  
	cout << "is_iec559(float): " << numeric_limits<float>::is_iec559 << endl;
	// 不加+-号可以表示的位数  
	cout << "digits(float): " << numeric_limits<float>::digits << endl;
	// 十进制数的个数  
	cout << "digits10(float): " << numeric_limits<float>::digits10 << endl;
	// 一般基数为2  
	cout << "radix(float): " << numeric_limits<float>::radix << endl;
	// 以2为基数的最小指数  
	cout << "min_exponent(float): " << numeric_limits<float>::min_exponent << endl;
	// 以2为基数的最大指数  
	cout << "max_exponent(float): " << numeric_limits<float>::max_exponent << endl;
	// 以10为基数的最小指数  
	cout << "min_exponent10(float): " << numeric_limits<float>::min_exponent10 << endl;
	// 以10为基数的最大指数  
	cout << "max_exponent10(float): " << numeric_limits<float>::max_exponent10 << endl;
	// 1值和最接近1值的差距  
	cout << "epsilon(float): " << numeric_limits<float>::epsilon() << endl;
	// 舍入方式  
	cout << "round_style(float): " << numeric_limits<float>::round_style << endl;
	return 0;
}