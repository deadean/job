#include <stdio.h>
#include <conio.h>
#include <math.h>
#include <locale.h>
#include <windows.h>
#include <string.h>

struct Node{
	char* value;
	Node* next;
	Node* head;
	Node* tail;
};

HANDLE hStdout;
COORD coord;

void DrawArea();
void DrawResults(void(*pf)(Node*), Node* list);
void DrawMenu();

void PrintAsCyclicalList(Node* list);
void PrintAsStack(Node* list);
void PrintAsQueue(Node* list);

char* GetInputString();
bool IsNotNullList(Node* list);
Node* GetListFromConsole();

char* GetNextElementFromList(Node ** pNode);
void AddElementIntoList(Node **pNode, char* nValue);
Node* RemoveElementFromList(Node* list, char* value);

const char* IDENTIFIER_EXIT = ".";
const int DrawingAreaLength = 60;

void AddElementIntoList(Node **pNode, char* nValue) {
	Node * pNewNode = (Node*)malloc(sizeof(Node));
	pNewNode->value = nValue;
	if (!*pNode) {
		pNewNode->next = pNewNode;
		pNewNode->head = pNewNode;
		pNewNode->tail = NULL;
		*pNode = pNewNode;
	}
	else {
		pNewNode->next = (*pNode)->head;
		pNewNode->head = (*pNode)->head;

		pNewNode->tail = (*pNode);

		(*pNode)->next = pNewNode;
		*pNode = pNewNode;
	}
}

char* GetNextElementFromList(Node ** pNode) {
	char* value;
	value = (*pNode)->value;

	if ((*pNode)->next != *pNode) {
		Node * pPrev = (*pNode)->next;
		while (pPrev->next != *pNode)
			pPrev = pPrev->next;
		pPrev->next = (*pNode)->next;
		*pNode = pPrev->next;
	}

	return value;
}

char* GetNextElementFromListAndFreeMemory(Node ** pNode) {
	char* value;
	value = (*pNode)->value;

	if ((*pNode)->next == *pNode) {
		free(*pNode);
		*pNode = NULL;
	}
	else {
		Node * pPrev = (*pNode)->next;
		while (pPrev->next != *pNode)
			pPrev = pPrev->next;
		pPrev->next = (*pNode)->next;
		free(*pNode);
		*pNode = pPrev->next;
	}

	return value;
}

char* GetInputString(){
	char * str = NULL;
	while (true)
	{
		int symbol = _getch();
		if (symbol == 13){
			break;
		}

		int size = 0;
		if (str == NULL){
			size = sizeof(char) * 1;
			str = (char*)realloc(str, sizeof(char)*(size));
		}
		else{
			size = sizeof(char) * strlen(str);
			str = (char*)realloc(str, sizeof(char)*(size + 1));
			size = size + 1;
		}

		str[size - 1] = (char)symbol;
		str[size] = '\0';
		printf("%c", (char)symbol);
	}
	return str;
}

void DrawArea()
{
	coord.X = 0;
	coord.Y = 9;
	SetConsoleCursorPosition(hStdout, coord);
	printf("==============================================================");
	for (int i = 0; i <= 2; i++)
	{
		printf("\n%c", 186);
		for (int ii = 0; ii < DrawingAreaLength; ii++)
		{
			printf("%c", ' ');
		}
		printf("%c", 186);
	}
	printf("\n==============================================================");
	coord.X = 1;
	coord.Y = 10;
	SetConsoleCursorPosition(hStdout, coord);
}

void DrawMenu()
{
	Node* list = NULL;
	while (true){
		char* elementForRemove = NULL;
		system("cls");
		coord.X = 0;
		coord.Y = 0;
		SetConsoleCursorPosition(hStdout, coord);
		SetConsoleTextAttribute(hStdout, FOREGROUND_INTENSITY | FOREGROUND_RED | FOREGROUND_BLUE);
		printf("==========================Choose action=========================");
		printf("\n1.Remove element\n2.Print as a cyclical list\n3.Print as stack.\n4.Print as queue\n5.Input new list\n6.Exit");
		printf("\n==============================================================\nAction: ");
		char c = getchar();

		switch (c)
		{
		case '6':
			SetConsoleTextAttribute(hStdout, FOREGROUND_INTENSITY | FOREGROUND_RED);
			if (list != NULL){
				printf("\nFree memory..");
				while (list->next != list){
					GetNextElementFromList(&list);
				}
			}
			return;
			break;
		case '1':
			if (IsNotNullList(list)){
				printf("\nEnter element for removing: ");
				elementForRemove = GetInputString();
				list = RemoveElementFromList(list, elementForRemove);
				DrawResults(PrintAsCyclicalList, list);
			}
			break;
		case '2':
			if (IsNotNullList(list)){
				DrawResults(PrintAsCyclicalList, list);
			}
			
			break;
		case '3':
			if (IsNotNullList(list)){
				DrawResults(PrintAsStack, list);
			}
			break;
		case '4':
			if (IsNotNullList(list)){
				DrawResults(PrintAsQueue, list);
			}
			break;
		case '5':
			coord.X = 0;
			coord.Y = 8;
			SetConsoleCursorPosition(hStdout, coord);
			SetConsoleTextAttribute(hStdout, FOREGROUND_INTENSITY | FOREGROUND_RED);
			printf("Input elements into list. Enter symbol . to show menu.\n");
			SetConsoleTextAttribute(hStdout, FOREGROUND_RED | FOREGROUND_INTENSITY | FOREGROUND_BLUE);
			list = GetListFromConsole();
			continue;
			break;
		}
	}
}

void DrawResults(void(*pf)(Node*), Node* list)
{
	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_INTENSITY | FOREGROUND_RED);
	coord.X = 0;
	coord.Y = 10;
	SetConsoleCursorPosition(hStdout, coord);
	printf("====================Elements in the list======================");

	SetConsoleTextAttribute(hStdout, FOREGROUND_GREEN | FOREGROUND_INTENSITY);

	(*pf)(list);

	SetConsoleTextAttribute(hStdout, FOREGROUND_BLUE | FOREGROUND_INTENSITY | FOREGROUND_RED);

	printf("\n==============================================================\n");

	getchar();
	getchar();
}

void PrintAsCyclicalList(Node* list){
	Node* startElement = list;
	while (list->next != list){
	char *value = GetNextElementFromList(&list);
	printf("\n%s", value);
	}

	list->next = startElement;
	printf("\n%s", list->value);
}

void PrintAsQueue(Node* list){
	Node* startElement = list->head;
	Node* currentElement = list->head;
	Node* listClone = list;

	printf("\n%s", currentElement->value);
	currentElement = currentElement->next;
	while (currentElement != startElement){
		char *value = currentElement->value;
		printf("\n%s", value);
		currentElement = currentElement->next;
	}

	list = listClone;
}

void PrintAsStack(Node* list){
	Node* currentElement = list;
	Node* listClone = list;

	if (list == list->head){
		currentElement = list->tail;
	}

	printf("\n%s", currentElement->value);
	Node* startElement = currentElement;
	currentElement = currentElement->tail;
	while (currentElement != NULL && currentElement != startElement){
		char *value = currentElement->value;
		printf("\n%s", value);
		currentElement = currentElement->tail;
	}

	list = listClone;
}

Node* RemoveElementFromList(Node* list, char* value)
{
	Node * current = list;
	Node * previousElement = NULL;
	Node* elementForRemove = NULL;
	do {
		if (!strcmp(current->value, value)){
			elementForRemove = (Node*)current;
			break;
		}
		current = current->next;
	} while (current != list);

	current = list;
	do {
		if (current->next == elementForRemove){
			previousElement = current;
			break;
		}
		current = current->next;
	} while (current != list);

	if (elementForRemove == NULL)
		printf("Input element doesnt exist in a list");
	else{
		if (list->head == elementForRemove){
			Node* startElement = list;
			Node* currentElement = list;

			currentElement->head = elementForRemove->next;
			currentElement = currentElement->next;
			while (currentElement != startElement){
				if (currentElement == elementForRemove){
					currentElement = currentElement->next;
					continue;
				}
				currentElement->head = elementForRemove->next;
				currentElement = currentElement->next;
			}
		}

		if (list == elementForRemove){
			list = elementForRemove->next;
		}
		
		previousElement->next = elementForRemove->next;
		elementForRemove->next->tail = previousElement;
	}
	return list;
}

Node* GetListFromConsole(){
	Node* list = NULL;
	while (true)
	{
		DrawArea();

		char *str = GetInputString();

		if (str == NULL)
			continue;

		if (strstr(str, IDENTIFIER_EXIT) != NULL)
		{
			SetConsoleCursorPosition(hStdout, coord);
			break;
		}

		SetConsoleCursorPosition(hStdout, coord);

		AddElementIntoList(&list, str);
	}
	return list;
}

bool IsNotNullList(Node* list){
	if (list == NULL){
		printf("List doesnt contain any elements. Try to add new elements...");
		getchar();
		getchar();
	}
	return list != NULL;
}

int main()
{
	hStdout = GetStdHandle(STD_OUTPUT_HANDLE);

	DrawMenu();

	printf("\nProgramm has sheadped..");

	getchar();
	getchar();
	return 0;
}

