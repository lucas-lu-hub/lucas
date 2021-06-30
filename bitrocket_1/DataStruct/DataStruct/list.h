#ifndef _LIST_H_
#define _LIST_H_

#include"common.h"
///////////////////////////////////////////////////////////////////////////////
//��ͷ��˫ѭ������
typedef struct DCListNode
{
	ElemType data;
	struct DCListNode *next;
	struct DCListNode *prev;
}DCListNode;

typedef struct DCList
{
	DCListNode *head;
}DCList;

static DCListNode* _Buydnode(ElemType x);
void DCListInit(DCList *plist);
void DCListPushBack(DCList *plist, ElemType x);
void DCListPushFront(DCList *plist, ElemType x);
void DCListShow(DCList *plist);
void DCListPopBack(DCList *plist);
void DCListPopFront(DCList *plist);
DCListNode* DCListFind(DCList *plist, ElemType key);
size_t DCListLength(DCList *plist);
void DCListClear(DCList *plist);
void DCListDestroy(DCList *plist);
void DCListDeleteByVal(DCList *plist, ElemType key);
void DCListInsertByVal(DCList *plist, ElemType x);
void DCListReverse(DCList *plist);
void DCListSort(DCList *plist);

static DCListNode* _Buydnode(ElemType x)
{
	DCListNode *s = (DCListNode*)malloc(sizeof(DCListNode));
	assert(s != NULL);
	s->data = x;
	s->next = s->prev = s;
	return s;
}
void DCListInit(DCList *plist)
{
	plist->head = _Buydnode(0);
}

void DCListPushBack(DCList *plist, ElemType x)
{
	assert(plist != NULL);
	DCListNode *s = _Buydnode(x);
	
	s->prev = plist->head->prev;
	s->prev->next = s;
	s->next = plist->head;
	plist->head->prev = s;
}

void DCListPushFront(DCList *plist, ElemType x)
{
	assert(plist != NULL);
	DCListNode *s = _Buydnode(x);

	s->next = plist->head->next;
	s->prev = plist->head;
	s->next->prev = s;
	plist->head->next = s;
}

void DCListShow(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	while(p != plist->head)
	{
		printf("%d->", p->data);
		p = p->next;
	}
	printf("Over.\n");
}

void DCListPopBack(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->prev;
	if (p == plist->head)
		return;

	plist->head->prev = p->prev;
	p->prev->next = plist->head;
	free(p);
}
void DCListPopFront(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	if (p == plist->head)
		return;
	plist->head->next = p->next;
	p->next->prev = plist->head;
	free(p);
}

DCListNode* DCListFind(DCList *plist, ElemType key)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	while(p!=plist->head && p->data!=key)
		p = p->next;
	if(p != plist->head)
		return p;
	return NULL;
}

size_t DCListLength(DCList *plist)
{
	assert(plist != NULL);
	size_t len = 0;
	DCListNode *p = plist->head->next;
	while(p != plist->head)
	{
		len++;
		p = p->next;
	}
	return len;
}

void DCListClear(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	while(p != plist->head)
	{
		p->next->prev = p->prev;
		p->prev->next = p->next;
		free(p);
		p = plist->head->next;
	}
}

void DCListDestroy(DCList *plist)
{
	DCListClear(plist);
	free(plist->head); //�ͷ�ͷ���
	plist->head = NULL;
}

void DCListDeleteByVal(DCList *plist, ElemType key)
{
	assert(plist != NULL);
	DCListNode *p = DCListFind(plist, key);
	if(p == NULL)
		return;

	p->next->prev = p->prev;
	p->prev->next = p->next;
	free(p);
}

void DCListInsertByVal(DCList *plist, ElemType x)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	
	while(p!=plist->head && p->data<x)
		p = p->next;

	DCListNode *s = _Buydnode(x);
	s->next = p;
	s->prev = p->prev;
	p->prev->next = s;
	p->prev = s;
}

void DCListReverse(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	DCListNode *q = p->next;

	//�Ͽ�����
	p->next = plist->head;
	plist->head->prev = p;
	while(q != plist->head)
	{
		p = q;
		q = q->next;

		p->next = plist->head->next;
		p->prev = plist->head;
		p->next->prev = p;
		p->prev->next = p; // plist->head->next = p;
	}
}

void DCListSort(DCList *plist)
{
	assert(plist != NULL);
	DCListNode *p = plist->head->next;
	DCListNode *q = p->next;

	p->next = plist->head;
	plist->head->prev = p;

	while(q != plist->head)
	{
		p = q;
		q = q->next;

		//Ѱ��p�Ĳ���λ��
		DCListNode *t = plist->head->next;
		while(t!=plist->head && t->data<p->data)
			t = t->next;

		p->next = t;
		p->prev = t->prev;
		p->next->prev = p;
		p->prev->next = p;

		p = q;
	}
}

///////////////////////////////////////////////////////////////////////////////
//��ͷ������
typedef struct SListNode
{
	ElemType data;
	struct SListNode *next;
}SListNode;

typedef struct SList
{
	SListNode *head;
}SList;

///////////////////////////////////////////////////////////////////////////////////
//������ĺ����ӿ�����
static SListNode* _Buynode(ElemType x);
void SListInit(SList *plist);
void SListPushBack(SList *plist, ElemType x);
void SListPushFront(SList *plist, ElemType x);
void SListPopBack(SList *plist);
void SListPopFront(SList *plist);
void SListDestroy(SList *plist);

void SListInsertByVal(SList *plist, ElemType x);

SListNode* SListFind(SList *plist, ElemType key);
void SListDeleteByVal(SList *plist, ElemType key);

void SListClear(SList *plist);
size_t SListLength(SList *plist);

void SListReverse(SList *plist);
void SListSort(SList *plist);

void SListShow(SList *plist);

//////////////////////////////////////////////////////////////////////////////////
//������ĺ����ӿ�ʵ��

static SListNode* _Buynode(ElemType x)
{
	SListNode *s = (SListNode*)malloc(sizeof(SListNode));
	assert(s != NULL);
	s->data = x;
	s->next = NULL;
	return s;
}

void SListInit(SList *plist)
{
	plist->head = NULL;
}

void SListPushBack(SList *plist, ElemType x)
{
	assert(plist != NULL);

	SListNode *s = _Buynode(x);

	//����Ľڵ�Ϊ��һ���ڵ�
	if(plist->head == NULL)
	{
		plist->head = s;
		return;
	}

	//O(n)
	SListNode *p = plist->head;
	//���������β���ڵ� 
	while(p->next != NULL)
		p = p->next;
	p->next = s;
}

void SListPushFront(SList *plist, ElemType x)
{
	assert(plist != NULL);
	SListNode *s = _Buynode(x);

	//O(1)
	s->next = plist->head;
	plist->head = s;
}

void SListPopBack(SList *plist)
{
	assert(plist != NULL);
	SListNode *p, *prev;
	if(plist->head == NULL)
		return;
	p = plist->head;
	//����ֻ��һ���ڵ�
	if(p->next == NULL)
		plist->head = NULL;
	else
	{
		while(p->next != NULL)
		{
			prev = p;
			p = p->next;
		}
		prev->next = NULL;
	}
	free(p);
}

void SListPopFront(SList *plist)
{
	assert(plist != NULL);
	SListNode *p = plist->head;
	if(plist->head == NULL)
		return;
	
	plist->head = p->next;
	free(p);
}

SListNode* SListFind(SList *plist, ElemType key)
{
	assert(plist != NULL);
	SListNode *p = plist->head;

	//������ NULL
	//����   P
	//������ NULL

	while(p!=NULL && p->data!=key)
		p = p->next;
	return p;
}

void SListDeleteByVal(SList *plist, ElemType key)
{
	assert(plist != NULL);
	SListNode *prev = NULL;
	SListNode *p = SListFind(plist, key);
	if(p == NULL)
	{
		printf("Ҫɾ���Ľڵ㲻����.\n");
		return;
	}

	if(p == plist->head)
		plist->head = p->next;
	else
	{
		prev = plist->head;
		while (prev->next != p)
			prev = prev->next;

		//ɾ���ڵ�
		prev->next = p->next;
	}
	free(p);
}


size_t SListLength(SList *plist)
{
	assert(plist != NULL);
	size_t len = 0;
	SListNode *p = plist->head;

	while(p != NULL)
	{
		len++;
		p = p->next;
	}
	return len;
}

void SListShow(SList *plist)
{
	assert(plist != NULL);
	SListNode * p = plist->head;
	while(p != NULL)
	{
		printf("%d-->", p->data);
		p = p->next;
	}
	printf("Over.\n");
}

void SListDestroy(SList *plist)
{
	SListClear(plist);
	plist->head = NULL;
}

void SListClear(SList *plist)
{
	assert(plist != NULL);
	SListNode *p = plist->head;
	while(p != NULL)
	{
		plist->head = p->next;
		free(p);
		p = plist->head;
	}
}


void SListReverse(SList *plist)
{
	assert(plist != NULL);
	SListNode *p = plist->head->next;
	SListNode *q;
	if(p->next == NULL)
		return;

	//�Ͽ���һ���ڵ�
	plist->head->next = NULL;
	while(p != NULL)
	{
		q = p->next;
		p->next = plist->head;
		plist->head = p;
		p = q;
	}
}

void SListInsertByVal(SList *plist, ElemType x)
{
	assert(plist != NULL);
	SListNode *prev = NULL;
	SListNode *p = plist->head;

	SListNode *s = _Buynode(x);

	while(p!=NULL && x>p->data)
	{
		prev = p;
		p = p->next;
	}

	if(prev == NULL) //��Ҫ����ͷ��
	{
		s->next = p;
		plist->head = s;
	}
	else
	{
		s->next = prev->next;
		prev->next = s;
	}
}

void SListSort(SList *plist)
{
	assert(plist != NULL);
	SListNode *p = plist->head->next;
	SListNode *q, *t, *prev = NULL;

	plist->head->next = NULL; //�Ͽ�����
	
	t = plist->head;
	while(p != NULL)
	{
		q = p->next;
		//��p�ڵ�ժ�����а�ֵ���룬����
		while(t!=NULL && p->data > t->data)
		{
			prev = t;
			t = t->next;
		}
		if(prev == NULL)
		{
			p->next = plist->head;
			plist->head = p;
		}
		else
		{
			p->next = prev->next;
			prev->next = p;
		}
		p = q;
		t = plist->head;
	}
}


///////////////////////////////////////////////////////////////////////////////////
/*
SListNode* SListFind(SList *plist, ElemType key)
{
	assert(plist != NULL);
	SListNode *p = plist->head;
	while(p != NULL)
	{
		if(p->data == key)
			return p;
		p = p->next;
	}
	return NULL;
}



/*
//��������ڵ�
typedef struct ListNode
{
	int data;
	struct ListNode *next;
}ListNode;

typedef ListNode* List;

//�������ͷ���
void ListInit(List *plist)  //ListNode **plist
{
	*plist = (ListNode*)malloc(sizeof(ListNode));
	assert(*plist != NULL);
	(*plist)->next = NULL;
}

//β�巨����������
void ListCreate_Tail(List *plist)
{
	assert(plist != NULL);

	ListNode *p = *plist;

	for(int i=1; i<=10; ++i)
	{
		ListNode *s = (ListNode *)malloc(sizeof(ListNode));
		assert(s != NULL);
		s->data = i;
		s->next = NULL;

		p->next = s;
		p = s;
	}
}

//ͷ�巨����������
void ListCreate_Head(List *plist)
{
	assert(plist != NULL);
	for(int i=1; i<=10; ++i)
	{
		ListNode *s = (ListNode*)malloc(sizeof(ListNode));
		assert(s != NULL);
		s->data = i;
		
		s->next = (*plist)->next;
		(*plist)->next = s;
	}
}

void ListShow(List plist)
{
	ListNode *p = plist->next;
	while(p != NULL)
	{
		printf("%d->", p->data);
		p = p->next;
	}
	printf("Over.\n");
}

/*
//��������ͷ���
void ListInit(List *plist)  //ListNode **plist
{
	*plist = NULL;
}

//β�巨����������
void ListCreate_Tail(List *plist)
{
	*plist = (ListNode*)malloc(sizeof(ListNode));
	assert(*plist != NULL);
	(*plist)->data = 1;
	(*plist)->next= NULL;

	ListNode *p = *plist;
	for(int i=2; i<=10; ++i)
	{
		ListNode *s = (ListNode*)malloc(sizeof(ListNode));
		assert(s != NULL);
		s->data = i;
		s->next = NULL;

		//���ӽڵ�
		p->next = s;
		p = s;
	}
}

//ͷ�巨����������
void ListCreate_Head(List *plist)
{
	(*plist) = (ListNode*)malloc(sizeof(ListNode));
	assert(*plist != NULL);
	(*plist)->data = 1;
	(*plist)->next = NULL;

	for(int i=2; i<=10; ++i)
	{
		ListNode *s = (ListNode*)malloc(sizeof(ListNode));
		assert(s != NULL);
		s->data = i;
		
		//���ӽڵ�
		s->next = (*plist);
		(*plist) = s;
	}
}

void ListShow(List plist)
{
	ListNode *p = plist;
	while(p != NULL)
	{
		printf("%d->", p->data);
		p = p->next;
	}
	printf("Over.\n");
}
*/

#endif /* _LIST_H_ */