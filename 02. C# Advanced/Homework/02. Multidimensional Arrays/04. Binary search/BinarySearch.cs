using System;

class BinarySearch
{
	static void Main()
	{
		Console.Write("Enter array length: ");
		int n = int.Parse(Console.ReadLine());
		int[] nums = new int[n];
		Console.WriteLine("Enter array elements (Int32) on one line, separated by spaces: ");
		string[] numsline = Console.ReadLine().Split(' ');
		for (int i = 0; i < n; i++)
		{
			nums[i] = int.Parse(numsline[i]);
		}
		Console.Write("Enter search value (Int32): ");
		int k = int.Parse(Console.ReadLine());

		Console.WriteLine("Index of {0} is {1}.", k, Array.BinarySearch(nums, k));
	}
}