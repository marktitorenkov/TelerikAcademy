using System;

class MatrixOfNumbers
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
			{
				Console.Write("{0} ", j + i + 1);
			}
			Console.WriteLine();
		}
	}
}