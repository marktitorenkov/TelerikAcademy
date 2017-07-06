using System;

namespace Task2
{
	/// <summary>
	/// Modify the previous program to skip duplicates.
	/// </summary>
	class Task3
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());
			int k = int.Parse(Console.ReadLine());

			PrintCombinations(n, k);
		}

		static void PrintCombinations(int n, int k)
		{
			PrintCombinations(n, k, new int[k], new bool[n]);
		}

		static void PrintCombinations(int n, int steps, int[] combination, bool[] usedN)
		{
			int k = combination.Length;

			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", combination));
				return;
			}

			for (int i = 0; i < n; i++)
			{
				if (usedN[i])
				{
					continue;
				}
				combination[k - steps] = i + 1;
				usedN[i] = true;
				PrintCombinations(n, steps - 1, combination, usedN);
				usedN[i] = false;
			}
		}
	}
}