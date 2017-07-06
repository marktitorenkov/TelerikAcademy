using System;

namespace Task4
{
	/// <summary>
	/// Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n.
	/// </summary>
	class Task4
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			PrintNonRepeatingPermutations(n);
		}

		static void PrintNonRepeatingPermutations(int n)
		{
			Recursion(n, n, new int[n], new bool[n]);
		}

		static void Recursion(int n, int steps, int[] permutation, bool[] used)
		{
			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", permutation));
				return;
			}

			for (int i = 0; i < n; i++)
			{
				if (used[i])
				{
					continue;
				}
				permutation[n - steps] = i + 1;
				used[i] = true;
				Recursion(n, steps - 1, permutation, used);
				used[i] = false;
			}
		}
	}
}