﻿using System;

class MaximalSum
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[] nums = new int[n];

		for (int i = 0; i < n; i++)
			nums[i] = int.Parse(Console.ReadLine());


		int max = int.MinValue;

		for (int startIndex = 0; startIndex < n; startIndex++)
		{
			int currentsum = 0;
			for (int i = startIndex; i < n; i++)
			{
				currentsum += nums[i];
				if (currentsum > max)
					max = currentsum;
			}
		}
		Console.WriteLine(max);
	}
}