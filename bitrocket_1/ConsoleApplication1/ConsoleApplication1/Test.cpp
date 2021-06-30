#include<stdio.h>
#include<stdbool.h>

#include<iostream>
using namespace std;

//ָ������ int * p1[ ]
//��
//����ָ��int (*p2) [5]�� p1��p2��������ʲô?

void main()
{
	int a = 10;
	printf("%s\n", typeid(a).name());
	int ar[2] = {0};
	printf("%s\n", typeid(ar).name());

	int* p1[3] = {0};
	printf("%s\n", typeid(p1).name());  //int* [3];

	int (*p2) [5];
	printf("%s\n", typeid(p2).name());  //int(*)[5];

}


/*
//ָ������  ����ָ��
//C���ͼ�鲻�ϸ�
//C++ �ǳ��ϸ�
void main()
{
	int ar[10] = {1,2,3,4,5,6,7,8,9,10};
	printf("0x%p\n", &ar[0]);
	printf("0x%p\n", ar);
	printf("0x%p\n", &ar);

	int *p1 = &ar[0];
	int *p2 = ar;
	int (*p3)[10] = &ar;

	printf("%p : %p\n", ar, ar+1);
	printf("%p : %p\n", &ar, &ar+1);
}

/*
void main()
{
	int ar[] = {1,2,3,4,5,6,7,8,9,10,20,30,40,50};
	printf("ar size = %d\n", sizeof(ar));
	int n = sizeof(ar) / sizeof(ar[0]);
	printf("n = %d\n", n);

	printf("0x%p\n", &ar[0]);
	printf("0x%p\n", ar);
	printf("0x%p\n", &ar);
}

/*
void main()
{
	int ar[10]; //δ��ʼ��
	int br[10] = {1,2,3,4,5,6,7,8,9,10}; //��ȫ��ʼ��
	int cr[10] = {1,2,3,4,5}; //δ��ȫ��ʼ��
	int dr[100] = {0};

	int er[10];
	for(int i=1; i<=5; ++i)
	{
		er[i-1] = i;  //��ֵ
	}
}

/*
void main()
{
	int a = 1;
	int b = 2;
	int c = 3;

	int* ar[3] = {&a, &b, &c}; //ָ������

	int br[3] = {10,20,30};
	int(*par)[3] = &br;  //����ָ�� 
}



/*
//ָ�뺯��  ����ָ��

/*
int main()
{
	char str1[] = "hello bit.";
	char str2[] = "hello bit.";

	char *str3  = "hello bit.";
	char *str4  = "hello bit.";

	if (str1 == str2)
		printf("str1 and str2 are same\n");
	else
		printf("str1 and str2 are not same\n");

	if (str3 == str4)
		printf("str3 and str4 are same\n");
	else
		printf("str3 and str4 are not same\n");
	return 0;
}


/*
//ָ������ ��ָ��
//ָ�� == ��ַ  ָ��������ֵ�������ֵ��ָ���ֵ��

void main()
{
	char ch = 'A';
	char *pc = &ch;

	//�ַ���
	char *str = "Hello Bit.";
	printf("str = %s\n", str);
	printf("str size = %d\n", sizeof(str));
	str[0] = 'h';

	char str1[] = "Hello Bit.";
	printf("str1 = %s\n", str1);
	printf("str1 size = %d\n", sizeof(str1));
	str1[0] = 'h';
}


/*
void main()
{
	int a = 10;
	//a = 100;
	int *pa = &a; //paָ�����
	printf("a = %d\n", a);
	printf("*pa = %d\n", *pa);

	*pa = 20;

	printf("a = %d\n", a);
	printf("*pa = %d\n", *pa);

}

/*
void main()
{
	int a = 10;
	int b = 20;

	int *p = NULL;
	int **s = NULL;

	p = &a;
	s = &p;

	*p = 100;
	*s = &b;
}

/*
void main()
{
	char ch = 'A';  //xxx���� = xxx����
	int i = 10;

	char *pc = &ch; //�ַ�ָ����� = �ַ�ָ�� ==�� ָ��==��ַ
	int  *pi = &i;  //����ָ����� = ����ָ��
}

/*
void main()
{
	printf("%d\n",sizeof(bool *));
	printf("%d\n",sizeof(char ****));
	printf("%d\n",sizeof(short **));
	printf("%d\n",sizeof(int ****));
	printf("%d\n",sizeof(float *));
	printf("%d\n",sizeof(long *));
	printf("%d\n",sizeof(long long *));
	printf("%d\n",sizeof(double *));
}

/*
int main()
{
	int n = 9;
	float *pFloat = (float *)&n;
	printf("n��ֵΪ��%d\n", n);
	printf("*pFloat��ֵΪ��%f\n", *pFloat);
	*pFloat = 9.0;
	printf("num��ֵΪ��%d\n", n);
	printf("*pFloat��ֵΪ��%f\n", *pFloat);
	return 0;
}


/*
void main()
{
	float f = 12.125; //
	//1  //2  //3

	//1 ����һ��float���ݣ��ܹ��ֶ��Ƴ��ڴ�Ĵ洢
	//2 ����һ���ڴ��float���ݣ�Ҫ�ܹ��ָ�����ʵ��float����
	//double d;
}

/*
void main()
{
	int a = 9;  //00 00 00 0a
	int *pa = &a;
	printf("%d\n", *pa);
	float *pf = (float*)&a;
	printf("%f\n", *pf);
}
*/