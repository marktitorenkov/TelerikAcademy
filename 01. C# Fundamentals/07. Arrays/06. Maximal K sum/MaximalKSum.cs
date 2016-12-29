using System;

class MaximalKSum
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int k = int.Parse(Console.ReadLine());

		int[] nums = new int[n];
		int sum = 0;

		for (int i = 0; i < n; i++)
		{
			nums[i] = int.Parse(Console.ReadLine());
		}

		for (int j = 0; j < k; j++)
		{
			for (int i = 0; i < n - 1 - j; i++)
			{
				if (nums[i] > nums[i + 1])
				{
					int temp = nums[i];
					nums[i] = nums[i + 1];
					nums[i + 1] = temp;
				}
			}
			sum += nums[n - j - 1];
		}

		Console.WriteLine(sum);
	}
}