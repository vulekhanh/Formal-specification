using System;

public class ArraySort {

	static void swap(int[] arr, int i, int j)
	{
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}

	static void quickSort(int[] arr, int left, int right)
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
    }
	// Function to print an array
	static void printArray(int[] arr, int size)
	{
		for (int i = 0; i < size; i++)
			Console.Write(arr[i] + " ");

		Console.WriteLine();
	}

	// Driver Code
	public static void Main()
	{
        int size;
        Console.WriteLine("Enter the number of elements: ");
        size = Convert.ToInt32(Console.ReadLine());
		int[] arr = new int [size] ;
		
        for (int i = 0; i < size ; i++)
            arr[i] = Convert.ToInt32(Console.ReadLine());

		quickSort(arr, 0, size - 1);
		Console.Write("Sorted array: ");
		printArray(arr, size);
	}
}


