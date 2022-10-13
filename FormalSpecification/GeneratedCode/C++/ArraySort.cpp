#include <iostream>
using namespace std;

void quickSort(int arr[], int left, int right)
{
    if (left >= right)
      return;

    int middle = left + (right - left) / 2;
    int pivot = arr[middle];
    int i = left, j = right;

    while (i <= j) {
      while (arr[i] < pivot) {
        i++;
      }

      while (arr[j] > pivot) {
        j--;
      }

      if (i <= j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
        i++;
        j--;
      }
    }

    if (left < j)
      quickSort(arr, left, j);

    if (right > i)
      quickSort(arr, i, right);
	
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
	

	quickSort(arr, 0, size - 1);

	for (int i = 0; i < size; i++) {
		cout << arr[i] << " ";
	}

	return 0;
}
