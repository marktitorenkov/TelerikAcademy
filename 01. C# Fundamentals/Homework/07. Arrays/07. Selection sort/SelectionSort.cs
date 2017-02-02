using System;

class SelectionSort
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] nums = new int[n];
		for (int i = 0; i <	n; i++)
			nums[i] = int.Parse(Console.ReadLine());

		for (int j = 0; j < n - 1; j++)
		{
			int min = j;
			for (int i = j + 1; i < n; i++)
			{
				if (nums[i] < nums[min])
					min = i;
			}
			int temp = nums[j];
			nums[j] = nums[min];
			nums[min] = temp;
		}

		for (int i = 0; i < n; i++)
			Console.WriteLine(nums[i]);
	}
}