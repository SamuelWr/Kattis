// walrusweights.cpp : main project file.

#include "stdafx.h"
#include "stdio.h"

void addWeight(int, bool[]);



int main()
{
	//Console::WriteLine(L"Hello World");
	int numWeights;
	int currWeight;
	bool possible[2001];
	
	//scanf("%d", &seed);
	

	possible[0] = true;
	for (int i = 1; i < 2001; i++) {
		possible[i] = false;
	}

	scanf("%d", &numWeights);

	for (int i = 0; i < numWeights; i++){
		scanf("%d", &currWeight);
		addWeight(currWeight, possible);
	}
	
	/*printf("\nReachable weights:\n");
	for (int i = 0; i < 2001; i++){
		if (possible[i]) {
			printf(" %d", i);
		}
	}*/

	//TODO: store best yet in global variables instead?
	for (int i = 0; i < 1001; i++) {
		if (possible[1000 + i]) {
			printf("%d", 1000+i);
			break;
		}
		if (possible[1000 - i]) {
			printf("%d", 1000-i);
			break;
		}
	}

	return 0;
}

void addWeight(int weight, bool possible[]) {
	for (int i = 1000; i >= 0; i--){
		if (possible[i]) {
			possible[i + weight] = true;
		}
	}
}