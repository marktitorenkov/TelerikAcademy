using System;
using System.Linq;

namespace Task5
{
	/// <summary>
	/// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations).
	/// {hi, a, b}, k=2 → (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
	/// </summary>
	class Task5
	{
		static void Main()
		{
			string[] elements = Console.ReadLine().Split(' ').ToArray();
			int k = int.Parse(Console.ReadLine());

			PrintVariations(elements, k);
		}

		static void PrintVariations(string[] elements, int k)
		{
			Recursion(k, k, elements, new string[k]);
		}

		static void Recursion(int steps, int k, string[] elements, string[] currentVar)
		{
			if (steps == 0)
			{
				Console.WriteLine(string.Join(" ", currentVar));
				return;
			}

			for (int i = 0; i < elements.Length; i++)
			{
				currentVar[k - steps] = elements[i];
				Recursion(steps - 1, k, elements, currentVar);
			}
		}
	}
}