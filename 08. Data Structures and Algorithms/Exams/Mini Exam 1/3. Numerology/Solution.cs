using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology
{
	class Program
	{
		static int[] counts = new int[10];

		static void Main()
		{
			var nums = Console.ReadLine().Select(x => x - '0').ToList();

			Recursion(nums);

			Console.WriteLine(string.Join(" ", counts));
		}

		static void Recursion(List<int> nums)
		{
			if (nums.Count == 1)
			{
				counts[nums[0]] += 1;
				return;
			}

			for (int i = 0; i < nums.Count - 1; i++)
			{
				int result = Operation(nums[i], nums[i + 1]);

				var numsCopy = new List<int>(nums);
				numsCopy.RemoveAt(i);
				numsCopy[i] = result;

				Recursion(numsCopy);
			}
		}

		static int Operation(int a, int b)
		{
			return (a + b) * (a ^ b) % 10;
		}
	}
}