#include<stdio.h>

#define ADD 1
#define SUB 2
#define MUL 3
#define DIV 4
#define MOD 5
#define QUIT 0

int Add(int a, int b){return a + b;}
int Sub(int a, int b){return a - b;}
int Mul(int a, int b){return a * b;}
int Div(int a, int b){return a / b;}
int Mod(int a, int b){return a % b;}
int Max(int a, int b){return a>b?a:b;}

//ת�Ʊ�
int(*fun_table[])(int, int) = {0, Add, Sub, Mul, Div, Mod, Max};

int main(int argc, char *argv[])
{
	//////////////////////////////////////////////////
	system("title ���׼�����");
	system("mode con cols=36 lines=10");
	system("color 0F");
	//////////////////////////////////////////////////

	int select = 1;
	while(select)
	{
		printf("************���׼�����**************\n");
		printf("* [1] �ӷ�               [2] ����  *\n");
		printf("* [3] �˷�               [4] ����  *\n");
		printf("* [5] ģ����             [0] �˳�  *\n");
		printf("************************************\n");
		printf("��ѡ��:>");
		scanf("%d", &select);

		if(select == QUIT)
			break;

		printf("input a and b:>");
		int a, b;
		scanf("%d %d", &a, &b);

		int result = fun_table[select](a, b); //

		//char oper[] = {'+','-','*','/', '%'};
		if(select == ADD)
			printf("%d + %d=%d\n",a,b,result);
		else if(select == SUB)
			printf("%d - %d=%d\n",a,b,result);
		else if(select == MUL)
			printf("%d * %d=%d\n",a,b,result);
		else if(select == DIV)
			printf("%d / %d=%d\n",a,b,result);
		else if(select == MOD)
			printf("%d \%% %d=%d\n",a,b,result);
		system("pause");
		system("cls");
	}
	return 0;
}

/*
#define ADD 1
#define SUB 2
#define MUL 3
#define DIV 4
#define MOD 5
#define QUIT 0

int Add(int a, int b){return a + b;}
int Sub(int a, int b){return a - b;}
int Mul(int a, int b){return a * b;}
int Div(int a, int b){return a / b;}
int Mod(int a, int b){return a % b;}

int main(int argc, char *argv[])
{
	//////////////////////////////////////////////////
	system("title ���׼�����");
	system("mode con cols=36 lines=10");
	system("color 0F");
	//////////////////////////////////////////////////

	int select = 1;
	while(select)
	{
		printf("************���׼�����**************\n");
		printf("* [1] �ӷ�               [2] ����  *\n");
		printf("* [3] �˷�               [4] ����  *\n");
		printf("* [5] ģ����             [0] �˳�  *\n");
		printf("************************************\n");
		printf("��ѡ��:>");
		scanf("%d", &select);

		if(select == QUIT)
			break;

		printf("input a and b:>");
		int a, b;
		scanf("%d %d", &a, &b);

		int result = 0;
		switch(select)
		{
		case ADD:
			result = Add(a, b);
			break;
		case SUB:
			result = Sub(a, b);
			break;
		case MUL:
			result = Mul(a, b);
			break;
		case DIV:
			result = Div(a, b);
			break;
		case MOD:
			result = Mod(a, b);
			break;
		default:
			printf("Command Error, Please Input Again....\n");
			system("pause");
			system("cls");
			continue;
		}

		//char oper[] = {'+','-','*','/', '%'};
		if(select == ADD)
			printf("%d + %d=%d\n",a,b,result);
		else if(select == SUB)
			printf("%d - %d=%d\n",a,b,result);
		else if(select == MUL)
			printf("%d * %d=%d\n",a,b,result);
		else if(select == DIV)
			printf("%d / %d=%d\n",a,b,result);
		else if(select == MOD)
			printf("%d \%% %d=%d\n",a,b,result);
		system("pause");
		system("cls");
	}
	return 0;
}

/*
void fun1()
{
	printf("This is fun1.\n");
}
void fun2()
{
	printf("This is fun1.\n");
}
void fun3()
{
	printf("This is fun1.\n");
}

void main()
{
	int a = 1;
	int b = 2;
	int c = 3;
	int* ar[3] = {&a, &b, &c};

	void(*br[3])() = {&fun1, &fun2, &fun3};
}


/*
//����1
(*(void (*)())0)();

//����2
void (*signal(int , void(*)(int)))(int);

/*
//ָ������ ����ָ�� 
//����ָ�� ָ�뺯��
int * (* (*fun) (int *)) [10]

/*
�ñ���a��������Ķ���
a) һ��������  int a;
b) һ��ָ����������ָ��
c) һ��ָ��ָ���ָ�룬��ָ���ָ����ָ��һ��������
d) һ����10��������������
e) һ����10��ָ������飬��ָ����ָ��һ���������ġ�
f) һ��ָ����10�������������ָ��
g) һ��ָ������ָ�룬�ú�����һ�����Ͳ���������һ��������
h) һ����10��ָ������飬��ָ��ָ��һ��������
   �ú�����һ�����Ͳ���������һ��������

a> int a;
b> int* a;
c> int** a;
d> int a[10];
e> int* a[10];
f> int (a*)[10];
g> int (*a)(int);
h> int(*a[10])(int)



/*
void fun()
{
	printf("Hello Bit.\n");
}
int max(int a, int b)
{
	return a > b ? a : b;
}

void main()
{
	fun();

	void(*pfun)(); // ����ָ��

	pfun = &fun;
	(*pfun)();

	pfun = fun;
	pfun();

	int(*pfun1)(int, int);
	pfun1 = max;  //Error
	pfun1(10,20);
}

/*
void main()
{
	printf("%p\n", fun);
	printf("%p\n", &fun);  // �ȼ�

	fun();
}

/*
void main()
{
	fun();
	max(10,20);
}

/*
//test1�����ܽ���ʲô������
void test1(int *p)
{}

//test2�����ܽ���ʲô������
void test2(char* p)
{}

void test3(int **ptr)
{}

void main()
{
	int a = 10;
	int *pa = &a;

	test3(&pa);

}

/*
void main()
{
	int a = 10;
	test1(&a);

	int ar[3] = {0};
	test1(ar);

	char ch = 'A';
	test2(&ch);

	char cr[3] = {'a','b','c'};
	test2(cr);
}

/*
void test(int arr[])//ok?
{}
void test1(int arr[10])//ok?
{}
void test2(int *arr)//ok?
{}
void test3(int *arr[])//ok?  //Error  int **arr
{}
void test4(int **arr)
{}


void main()
{
	int ar[] = {1,2,3,4,5,6,7,8,9,10};
	int n = sizeof(ar) / sizeof(ar[0]);
	//test3(ar);

	int *br[10] = {0};
	test4(br);
}

/*
int arr[5];
int* parr1[10];
int (*parr2)[10];

int (* parr3[10])[5];  //����ָ�� ����

/*
#define ROW 5
#define COL 5

void PrintArray2(int(*pa)[COL], int row, int col)
{
	for(int i=0; i<row; ++i)
	{
		for(int j=0; j<col; ++j)
		{
			printf("%d ", pa[i][j]);
		}
		printf("\n");
	}
}

void PrintArray3(int pa[ROW][COL], int row, int col)
{
	for(int i=0; i<row; ++i)
	{
		for(int j=0; j<col; ++j)
		{
			printf("%d ", pa[i][j]);
		}
		printf("\n");
	}
}

void main()
{
	int ar[ROW][COL] = {0};
	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			ar[i][j] = i+j;
		}
	}

	PrintArray3(ar, ROW, COL);
}

/*
void PrintArray1(int a[], int n)
{
	for(int i=0; i<n; ++i)
		printf("%d ", a[i]);
	printf("\n");
}
void main()
{
	int ar[] = {1,2,3,4,5,6,7,8,9,10};
	int n = sizeof(ar) / sizeof(ar[0]);
	PrintArray1(ar, n);
}


/*
void PrintArray1(int a[])
{
	printf("ar size = %d\n", sizeof(a));
	int n = sizeof(a) / sizeof(a[0]);
	for(int i=0; i<n; ++i)
		printf("%d ", a[i]);
	printf("\n");
}
void main()
{
	int ar[] = {1,2,3,4,5,6,7,8,9,10};

	printf("ar size = %d\n", sizeof(ar));

	int n = sizeof(ar) / sizeof(ar[0]);
	PrintArray1(ar);
}

/*
void PrintArray()
{}

void main()
{
	int ar[ROW][COL] = {0};
	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			ar[i][j] = i+j;
		}
	}

	PrintArray();
}

/*
void main()
{
	int ar[ROW][COL] = {0};
	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			ar[i][j] = i+j;
		}
	}

	//printf("%d\n", sizeof(ar)); //25 * 4

	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			printf("%d ",ar[i][j]);
		}
		printf("\n");
	}

	////////////////////////////////////////////////////////
	int (*pa)[COL] = ar;
	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			printf("%d ",pa[i][j]);
		}
		printf("\n");
	}

	for(int i=0; i<ROW; ++i)
	{
		for(int j=0; j<COL; ++j)
		{
			printf("%d ", *(*(pa+i)+j));
		}
		printf("\n");
	}
}

/*
//��
void main()
{
	int a[3] = {1,2,3};
	a[0] = 10; // *(a+0) //
	a[1] = 20;
	a[2] = 30;

	0[a] = 100;// *(0+a) ==> 0[a];  ά����
}

/*
void main()
{
	int ar[10] = {1,2,3,4,5,6,7,8,9,10};
	for(int i=0; i<10; ++i)
		printf("%d ", ar[i]);   //�±�  [ ) 0 1 2 3 4 5 6 7 8 9 
	printf("\n");

	for(int i=0; i<10; ++i)
		printf("%d ", *(ar+i));   //�±�  [ ) 0 1 2 3 4 5 6 7 8 9 
	printf("\n");

	int *pa = ar;
	for(int i=0; i<10; ++i)
		printf("%d ", *(pa+i));   //ָ��
	printf("\n");

	for(int i=0; i<10; ++i)
		printf("%d ", pa[i]);
	printf("\n");
}

/*
void main()
{
	int ar[10] = {1,2,3,4,5,6,7,8,9,10};
	printf("%p\n", &ar[0]);
	printf("%p\n", ar);
	printf("%p\n", &ar);

	printf("%d\n", sizeof(&ar[0]));  //4   4   4
	printf("%d\n", sizeof(ar));      //10  40  4
	printf("%d\n", sizeof(&ar));     //4   4   4

	int(*pa)[10] = &ar;
	//pa + 1;
}

/*
int main()
{
	int a = 10;
	int *pa = &a;
	return 0;
}
*/