#include <iostream>
using namespace std;

void searchIndex(int arr[], int size)
{
    int i = 0, j;
    bool foundIndex = false;
    for(i = 0; i < size; i++) {
        for (j = i +1; j < size; j++) {
            if (arr[i] <= arr[j]){
                foundIndex = true;
                break;
            }
        }
        if (foundIndex)
            break;
    }
    cout << i << " " << j << endl;
	
}

int main()
{
    int size;
    cout << "Enter array's size: ";
    cin >> size;

    int arr[size];
    cout << "Enter the numbers for array, each element is separated by a space: ";
    for (int i = 0 ; i < size; i++){
        cin >> arr[i];
    }
	
    searchIndex(arr, size);

	return 0;
}
