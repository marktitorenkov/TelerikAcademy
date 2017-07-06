using System;

namespace Task6
{
	/// <summary>
	/// Write a program for generating and printing all subsets of k strings from given set of strings.
	/// {test, rock, fun}, k=2 → (test rock), (test fun), (rock fun)
	/// </summary>
	class Task6
	{
		static void Main()
		{
			string[] elements = Console.ReadLine().Split(' ');
			int k = int.Parse(Console.ReadLine());

			PrintVariations(elements, k);
		}

		static void PrintVariations(string[] elements, int k)
		{
			Recursion(k, k, elements, new string[k], 0);
		}

		static void Recursion(int steps, int k, string[] elements, string[] currVarition, int currUsed)
		{
			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", currVarition));
				return;
			}

			int position = k - steps;
			for (int i = currUsed; i < elements.Length; i++)
			{
				currVarition[position] = elements[i];
				Recursion(steps - 1, k, elements, currVarition, ++currUsed);
			}
		}
	}
}