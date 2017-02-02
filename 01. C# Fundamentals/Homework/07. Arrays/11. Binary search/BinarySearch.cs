using System;

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] nums = new int[n];
		for (int i = 0; i < n; i++)
			nums[i] = int.Parse(Console.ReadLine());
		int x = int.Parse(Console.ReadLine());

		Console.WriteLine(BinarySearch(nums, x));
	}

	static int BinarySearch(int[] arr, int x)
	{
		int n = arr.Length;
		int l = 0;
		int r = n - 1;

		while (l <= r)
		{
			int m = (l + r) / 2;
			if (x > arr[m])
				l = m + 1;
			else if (x < arr[m])
				r = m - 1;
			else if (x == arr[m])
				return m;
		}
		return -1;
	}	
}