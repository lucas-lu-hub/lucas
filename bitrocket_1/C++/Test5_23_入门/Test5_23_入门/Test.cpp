#include<iostream>    //��������� in out stream
#include<algorithm>
#include"Test.h"
using namespace std;  //�����ռ�

//C++�������� C���Բ�����
//���������� -1������ͬ  2�����б�ͬ 3����ֻͨ������ֵ�Ĳ�ͬ�γ�����
extern "C" int Max(int a, int b)
{
	return a > b ? a : b;
}
extern "C" char Max(char a, char b)
{
	return a > b ? a : b;
}
double Max(double a, double b)
{
	return a > b ? a : b;
}
void main()
{
	cout<<Max(10,20)<<endl;
	cout<<Max('A','B')<<endl;   //��ʾת��
	cout<<Max(10.12,20.23)<<endl;
}

/*
int Add(int a, int b, int c) //Ĭ�ϲ���
{
	return a + b;
}

void main()
{
	printf("result = %d\n", Add(10, 20));
}

/*
int Add(int a=0, int b=0) //Ĭ�ϲ���
{
	return a + b;
}

void main()
{
	printf("result = %d\n", Add(10));
}

/*
//���ֳ�ͻ
namespace bit
{
	const int min(const int a, const int b)
	{
		return a > b ? b : a;
	}
};

void main()
{
	int a = 10;
	int b = 20;
	cout<<"Min Value = "<<bit::min(a,b)<<endl;
}

/*
namespace MySpace
{
	void fun()
	{
		cout << "This is fun 1." << endl;
	}
};
namespace YouSpace
{
	void fun()
	{
		cout << "This is fun 2." << endl;
	}
};

using YouSpace::fun; //
//using namespace YouSpace;
void main()
{
	MySpace::fun();
	fun();
}

/*
//��������
#define A

#ifdef A
void fun()
{
	cout<<"This is fun 1."<<endl;
}
#else
void fun()
{
	cout<<"This is fun 2."<<endl;
}
#endif

void main()
{
	fun();
}

/*
void main()
{
	int key;
	cout<<"������key:>";   //�����   ��������  ::��������ʷ�
	cin>>key;              //��ȡ��   ���������

	cout<<"key = "<<key<<endl;
}

/*
void main()
{
	int key;
	std::cout<<"������key:>";   //�����   ��������  ::��������ʷ�
	std::cin>>key;              //��ȡ��   ���������

	std::cout<<"key = "<<key<<std::endl;
}

/*
void main()
{
	int a = 10;
	char b = 'B';
	double c = 12.34;
	printf("a = %d, b = %c, c = %f\n", a, b, c);

	cout<<a<<endl;
	cout<<b<<endl;
	cout<<c<<endl;
}
*/