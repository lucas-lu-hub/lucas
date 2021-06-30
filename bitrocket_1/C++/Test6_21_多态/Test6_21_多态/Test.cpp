#include<iostream>
using namespace std;

class Base1 {
public:
	virtual void func1() { cout << "Base1::func1" << endl; }
	virtual void func2() { cout << "Base1::func2" << endl; }
private:
	int b1;
};
class Base2 {
public:
	virtual void func1() { cout << "Base2::func1" << endl; }
	virtual void func2() { cout << "Base2::func2" << endl; }
private:
	int b2;
};

class Derive : public Base1, public Base2 {
public:
	virtual void func1() { cout << "Derive::func1" << endl; }
	virtual void func3() { cout << "Derive::func3" << endl; }
private:
	int d1;
};
typedef void(*VFPTR) ();
void PrintVTable(VFPTR vTable[])
{
	cout << " ����ַ>" << vTable << endl;
	for (int i = 0; vTable[i] != nullptr; ++i)
	{
		printf(" ��%d���麯����ַ :0X%x,->", i, vTable[i]);
		VFPTR f = vTable[i];
		f();
	}
	cout << endl;
}

int main()
{
	Derive d;
	VFPTR* vTableb1 = (VFPTR*)(*(int*)&d);
	PrintVTable(vTableb1);

	VFPTR* vTableb2 = (VFPTR*)(*(int*)((char*)&d + sizeof(Base1)));
	PrintVTable(vTableb2);
	return 0;
}

/*
class Base
{
public:
	virtual void f(){cout<<"Base::f()"<<endl;}
	virtual void g(){cout<<"Base::g()"<<endl;}
	virtual void h(){cout<<"Base::h()"<<endl;}
};
class D : public Base
{
public:
	virtual void f1(){cout<<"D::f1()"<<endl;}
	virtual void g1(){cout<<"D::g1()"<<endl;}
	virtual void h1(){cout<<"D::h1()"<<endl;}
};

typedef void(*vfptr_type)();
void PrintVTable(vfptr_type vTable[])
{
	cout<<"����ַ = "<<vTable<<endl;
	for(int i=0; vTable[i]; ++i)
	{
		vTable[i]();
	}
}
void main()
{
	D d;
	vfptr_type *vfptr =  (vfptr_type*)(*(int*)&d); //??????
	PrintVTable(vfptr);
}

/*
//��̳е�����û�и��Ǹ���ķ���
class Base
{
public:
	virtual void f(){}
	virtual void g(){}
	virtual void h(){}
};

class Base1
{
public:
	virtual void f(){}
	virtual void g(){}
	virtual void h(){}
};

class Base2
{
public:
	virtual void f(){}
	virtual void g(){}
	virtual void h(){}
};

class D : public Base, public Base1, public Base2
{
public:
	virtual void f(){}
	virtual void g1(){}
	virtual void h1(){}
};

void main()
{
	D d;
}

/*
//���̳в������и��Ǹ���ķ���
class Base		[2]	0x00481622 {Test6_21_��̬.exe!Base::h(void)}	void *

{
public:
	virtual void f(){}
	virtual void g(){}
	virtual void h(){}
};
class D : public Base
{
public:
	virtual void f(){}
	virtual void g1(){}
	virtual void h1(){}
};

void main()
{
	D d;
}

/*
//���̳е�����û�и��Ǹ���ķ���
class Base
{
public:
	virtual void f(){}
	virtual void g(){}
	virtual void h(){}
};
class D : public Base
{
public:
	virtual void f1(){}
	virtual void g1(){}
	virtual void h1(){}
};

void main()
{
	D d;
}


/*
class A
{
public:
	//�ӿ�
	virtual void Eat() = 0; //���麯��
	virtual void Sleep() = 0;
	virtual void Foot() = 0;
};

class Person : public A
{
public:
	virtual void Eat()
	{
		cout<<"Person::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"Person::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"Person::Foot()"<<endl;
	}

};

class Dog : public A
{
public:
	virtual void Eat()
	{
		cout<<"Dog::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"Dog::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"Dog::Foot()"<<endl;
	}
};

void Active(A *pa)
{
	pa->Eat();
	pa->Foot();
	pa->Sleep();
}


void main()
{
	Person p;
	Active(&p);
}

/*
class Base
{
public:
	Base()
	{
		cout<<"Base::Base()"<<endl;
	}
	virtual ~Base()
	{
		cout<<"Base::~Base()"<<endl;
	}
public:
	virtual Base* fun()
	{
		cout<<"Base::fun()"<<endl;
		return this;
	}
private:
	int m_b = 0;
};

class D : public Base
{
public:
	D()
	{
		cout<<"D::D()"<<endl;
	}
	~D()
	{
		cout<<"D::~D()"<<endl;
	}
public:
	virtual D* fun()
	{
		cout<<"D::fun()"<<endl;
		return this;
	}
private:
	int m_d = 0;
};

void main()
{
	Base b;
	D d;
}


/*
//����
//������
class A
{
public:
	//�ӿ�
	virtual void Eat() = 0; //���麯��
	virtual void Sleep() = 0;
	virtual void Foot() = 0;
};

class Person : public A
{
public:
	virtual void Eat()
	{
		cout<<"Person::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"Person::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"Person::Foot()"<<endl;
	}

};

class Dog : public A
{
public:
	virtual void Eat()
	{
		cout<<"Dog::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"Dog::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"Dog::Foot()"<<endl;
	}
};

class Bird : public A
{
public:
	virtual void Eat()
	{
		cout<<"Bird::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"Bird::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"Bird::Foot()"<<endl;
	}
public:
	virtual void Fly()
	{
		cout<<"Bird::Fly()"<<endl;
	}
};

class TN : public Bird
{
public:
	virtual void Eat()
	{
		cout<<"TN::Eat()"<<endl;
	}
	virtual void Sleep()
	{
		cout<<"TN::Sleep()"<<endl;
	}
	virtual void Foot()
	{
		cout<<"TN::Foot()"<<endl;
	}
private:
	virtual void Fly();
};


//C++ ָ��  ����   �ṹ��
//���
void main()
{
	Bird b;
	b.Fly();
}

/*
class Base
{
public:
	virtual void f(float x){ cout << "Base::f(float) " << x << endl; }
	virtual void g(float x){ cout << "Base::g(float) " << x << endl; }
	void h(float x){ cout << "Base::h(float) " << x << endl; }
};

class Derived : public Base
{
public:
	virtual void f(float x){ cout << "Derived::f(float) " << x << endl; }
	void g(int x){ cout << "Derived::g(int) " << x << endl; }
	void h(float x){ cout << "Derived::h(float) " << x << endl; }
};

void main(void)
{
	Derived d;
	Base *pb = &d;
	Derived *pd = &d;

	// Good : behavior depends solely on type of the object
	pb->f(3.14f); // Derived::f(float) 3.14
	pd->f(3.14f); // Derived::f(float) 3.14

	// Bad : behavior depends on type of the pointer
	pb->g(3.14f); // Base::g(float) 3.14
	pd->g(3.14f); // Derived::g(int) 3 (surprise!)

	// Bad : behavior depends on type of the pointer
	pb->h(3.14f); // Base::h(float) 3.14 (surprise!)
	pd->h(3.14f); // Derived::h(float) 3.14
}

/*
//����  ���� ����
class Base
{
public:
	//���� -- ��̬
	virtual void fun()
	{}
};

class D: public Base
{
	void fun()
	{}
};

void main()
{}


/*
class Base
{
public:
	//����
	virtual void fun()
	{}
	void fun(int a)
	{}
};

void main()
{}

/*
//final  override  //C++11

class Car
{
public:
	virtual void Drive()
	{
		cout<<"Car::Drive()"<<endl;
	}
};
class Benz : public Car
{
public:
	virtual void Drive() override
	{
		cout << "Benz-����" << endl;
	}
};

void main()
{
	Benz bz;
	//bz.Drive(0);

	Car *pc = new Benz;
	pc->Drive();
}

/*
class Car
{
public:
	virtual void Drive()final
	{
		cout<<"Car::Drive()"<<endl;
	}
};
class Benz : public Car
{
public:
	virtual void Drive(int a) 
	{
		cout << "Benz-����" << endl;
	}
};

void main()
{
	Benz bz;
	//bz.Drive(0);

	Car *pc = new Benz;
	pc->Drive();
}


/*
class Car final
{
public:
	virtual void Drive() 
	{}
};
class Benz : public Car
{
public:
	virtual void Drive() 
	{
		cout << "Benz-����" << endl;
	}
};

void main()
{}

/*
class Base
{
public:
	Base()
	{
		cout<<"Base::Base()"<<endl;
	}
	virtual ~Base()
	{
		cout<<"Base::~Base()"<<endl;
	}
public:
	virtual Base* fun()
	{
		cout<<"Base::fun()"<<endl;
		return this;
	}
private:
	int m_b = 0;
};

class D : public Base
{
public:
	D()
	{
		cout<<"D::D()"<<endl;
	}
	~D()
	{
		cout<<"D::~D()"<<endl;
	}
public:
	virtual D* fun()
	{
		cout<<"D::fun()"<<endl;
		return this;
	}
private:
	int m_d = 0;
};

void main()
{
	Base *pb = new D; //��̬����
	delete pb;
}

/*
//32 4  //64 8
class Base
{
public:
	Base()
	{
		cout<<"Base::Base()"<<endl;
	}
public:
	virtual void fun(int a)
	{
		cout<<"Base::fun(int)"<<endl;
	}
	virtual void show()
	{
		cout<<"Base::show()"<<endl;
	}
	virtual void print()
	{
		cout<<"Base::print()"<<endl;
	}
private:
	int m_b = 0;
};

class D : public Base
{
public:
	D()
	{
		cout<<"D::D()"<<endl;
	}
public:
	//һ������������Ϊ��
	virtual void fun(int a)
	{
		cout<<"D::fun()"<<endl;
	}
	virtual void list()
	{
		cout<<"D::list()"<<endl;
	}
private:
	int m_d = 0;
};

class C : public D
{
public:
	virtual void fun(int a)
	{
		cout<<"C::fun(int)"<<endl;
	}
};

void main()
{
	D *pd = new C;
	pd->fun(0);
}

/*
void main()
{
	D d;
	Base *pb = &d;  //new D
	pb->fun(0);
	//pb->list();
}

/*
class Base
{
public:
	virtual void fun(int a)
	{
		cout<<"Base::fun(int)"<<endl;
	}
private:
	int m_b = 0;
};

class D : public Base
{
public:
	//��д  ��ͬ
	void fun(int a)
	{
		cout<<"D::fun()"<<endl;
	}
	virtual void show()
	{
		cout<<"D::show()"<<endl;
	}
private:
	int m_d = 0;
};

void main()
{
	Base b;
	D d;

	Base *pb = &d;
	pb->fun(0);

	//pb->show();

	//Base &rb = d;
	//rb.fun();
}

/*
class C : public Base
{
public:
	//��д
	void fun()
	{
		cout<<"C::fun()"<<endl;
	}
private:
	int m_c = 0;
};


/*
//��ͬ�Ĺ���--��̬
void Active(Base *pb)
{
	pb->fun();
}

void main()
{
	Base b;
	D d;
	C c;

	Active(&c);
}


/*
class Base
{
public:
	void fun()
	{
		cout<<"Base::fun()"<<endl;
	}
	void fun(int a)
	{
		cout<<"Base::fun(int)"<<endl;
	}
private:
	int m_b = 0;
};

class D : public Base
{
public:
	void fun()
	{
		cout<<"D::fun()"<<endl;
	}
private:
	int m_d = 0;
};

void main()
{
	Base b;
	D d;

	//��ֵ���ݹ���
	b = d; //1
	Base *pb = &d; //2
	Base &rb = d;  //3
}


/*
void main()
{
	D d;
	d.fun();
	//d.Base::fun(0);  //ͬ������
}
*/