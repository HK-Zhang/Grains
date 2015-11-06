void helloWorld()
{
	std::cout<<"Hello World!!!"<<std::endl;
}

void addTwoNumber()
{
	std::cout << "Enter two numbers:" << std::endl;
	int v1, v2;
	std::cin >> v1 >> v2;
	std::cout << "The sum of " << v1 << " and " << v2 << " is " << v1 + v2 << std::endl;
}

void moveBit()
{
	unsigned i,j;
	i=1;
	j=1<<i;
	std::cout<<j<<std::endl;
}

void forTest()
{
	for(;;)
	{
		for(int i=0;i<9600000;i++)
			_sleep(10);
	}
}

int main()
{
	//forTest();
	int a=0;
	helloWorld();
	moveBit();
	addTwoNumber();

	std::cin>>a;
	return 0;
}
