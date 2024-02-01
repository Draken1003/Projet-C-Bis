#include <iostream>

using namespace std;

int fibonacci_rec(int a)
{
	if (a == 1 || a == 2)
	{
		return 1;
	}
	else
	{
		return fibonacci_rec(a - 1) + fibonacci_rec(a - 2);
	}
}

int main()
{
	for (int i = 1; i <= 7; ++i) 
	{
		cout << fibonacci_rec(i) << " ";
	}
	return 0;
}