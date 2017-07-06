using System;

namespace Task2
{
	/// <summary>
	/// Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set.
	/// </summary>
	class Task2
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());

			PrintCombinations(n, k);
		}

		static void PrintCombinations(int n, int k)
		{
			PrintCombinations(n, k, new int[k]);
		}

		static void PrintCombinations(int n, int steps, int[] combination)
		{
			int k = combination.Length;

			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", combination));
				return;
			}

			for (int i = 0; i < n; i++)
			{
				combination[k - steps] = i + 1;
				PrintCombinations(n, steps - 1, combination);
			}
		}
	}
}