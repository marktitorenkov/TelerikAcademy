using System;

class SortingArray
{
	static int[] IntArrFromStr(string str)
	{
		string[] strarr = str.Split(' ');
		int[] arr = new int[strarr.Length];
		for (int i = 0; i < strarr.Length; i++)
		{
			arr[i] = int.Parse(strarr[i]);
		}
		return arr;
	}

	static void CukiSort(int[] arr)
	{
		for (int i = arr.Length - 1; i > -1; i--)
		{
			int swapIndex = LargestInSubArray(arr, i);

			if (arr[swapIndex] > arr[i])
			{
				int temp = arr[i];
				arr[i] = arr[swapIndex];
				arr[swapIndex] = temp;
			}
		}
	}

	static int LargestInSubArray(int[] arr, int index)
	{
		int largest = int.MinValue;
		int largestIndex = 0;

		for (int i = index; i > -1; i--)
		{
			if (arr[i] > largest)
			{
				largest = arr[i];
				largestIndex = i;
			}
		}

		return largestIndex;
	}

	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] nums = IntArrFromStr(Console.ReadLine());

		CukiSort(nums);

		Console.WriteLine(string.Join(" ", nums));
	}
}