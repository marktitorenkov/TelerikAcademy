using System;

class MaximalSum
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[] nums = new int[n];

		for (int i = 0; i < n; i++)
			nums[i] = int.Parse(Console.ReadLine());

		int max = nums[0];
		int currmax = nums[0];

		for (int i = 1; i < n; i++)
		{
			currmax = Math.Max(nums[i], currmax + nums[i]);
			if (currmax > max)
				max = currmax;
		}
		Console.WriteLine(max);
	}
}