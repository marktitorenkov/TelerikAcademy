using System;

namespace Task1
{
	/// <summary>
	/// Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.
	/// </summary>
	class Task1
	{
		static void Main()
		{
			int n = int.Parse(Console.ReadLine());

			PrintPermutations(n);
		}

		static void PrintPermutations(int n)
		{
			PrintPermutations(n, new int[n]);
		}

		static void PrintPermutations(int steps, int[] permutation)
		{
			int n = permutation.Length;

			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", permutation));
				return;
			}

			for (int i = 0; i < n; i++)
			{
				permutation[n - steps] = i + 1;
				PrintPermutations(steps - 1, permutation);
			}
		}
	}
}