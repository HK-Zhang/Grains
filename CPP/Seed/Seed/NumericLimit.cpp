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
	// ���Ա�ʾ�����ֵ  
	cout << "max(float): " << numeric_limits<float>::max() << endl;
	// ���Ա�ʾ�Ĵ���0����Сֵ���������͵�ʵ�ֻ���˲�ͬ  
	cout << "min(float): " << numeric_limits<float>::min() << endl;
	// ��׼���Ƿ�Ϊ��ʵ�����ػ�  
	cout << "is_specialized(float): " << numeric_limits<float>::is_specialized << endl;
	// �Ƿ����з��ŵģ������Ա�ʾ����ֵ  
	cout << "is_signed(float): " << numeric_limits<float>::is_signed << endl;
	// ���������ε�  
	cout << "is_integer(float): " << numeric_limits<float>::is_integer << endl;
	// �Ƿ��Ǿ�ȷ��ʾ��  
	cout << "is_exact(float): " << numeric_limits<float>::is_exact << endl;
	// �Ƿ���ڴ�С����  
	cout << "is_bounded(float): " << numeric_limits<float>::is_bounded << endl;
	// �����Ƚϴ������Ӷ��������������һ����С��ֵ  
	cout << "is_modulo(float): " << numeric_limits<float>::is_modulo << endl;
	// �Ƿ����ĳĳ��׼  
	cout << "is_iec559(float): " << numeric_limits<float>::is_iec559 << endl;
	// ����+-�ſ��Ա�ʾ��λ��  
	cout << "digits(float): " << numeric_limits<float>::digits << endl;
	// ʮ�������ĸ���  
	cout << "digits10(float): " << numeric_limits<float>::digits10 << endl;
	// һ�����Ϊ2  
	cout << "radix(float): " << numeric_limits<float>::radix << endl;
	// ��2Ϊ��������Сָ��  
	cout << "min_exponent(float): " << numeric_limits<float>::min_exponent << endl;
	// ��2Ϊ���������ָ��  
	cout << "max_exponent(float): " << numeric_limits<float>::max_exponent << endl;
	// ��10Ϊ��������Сָ��  
	cout << "min_exponent10(float): " << numeric_limits<float>::min_exponent10 << endl;
	// ��10Ϊ���������ָ��  
	cout << "max_exponent10(float): " << numeric_limits<float>::max_exponent10 << endl;
	// 1ֵ����ӽ�1ֵ�Ĳ��  
	cout << "epsilon(float): " << numeric_limits<float>::epsilon() << endl;
	// ���뷽ʽ  
	cout << "round_style(float): " << numeric_limits<float>::round_style << endl;
	return 0;
}