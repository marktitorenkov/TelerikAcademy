using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
	class Program
	{
		static void Main()
		{
			long p = long.Parse(Console.ReadLine());
			var nums = Console.ReadLine().Split(' ')
				.Select(long.Parse).ToList();
			long max = nums.Max();

			var arr = new List<long> { 0, 1 };
			for (int i = 2; arr[i - 1] <= max; i++)
			{
				if (i % 2 == 0)
				{
					arr.Add(arr[i / 2] * p);
				}
				else
				{
					arr.Add(arr[i / 2] * p + 1);
				}
			}

			var result = new long[nums.Count];
			for (int num = 0; num < nums.Count; num++)
			{
				long count = 0;
				for (int i = 1; i < arr.Count; i++)
				{
					for (int j = i; j < arr.Count; j++)
					{
						if (arr[i] + arr[j] == nums[num])
						{
							count++;
						}
					}
				}

				if (count == 1)
				{
					result[num] = 1;
				}
				else
				{
					result[num] = 0;
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
	}
}
