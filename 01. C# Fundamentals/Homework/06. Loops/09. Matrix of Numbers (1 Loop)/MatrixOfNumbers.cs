using System;

class MatrixOfNumbers
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());

		int i = 0;
		int j = 0;
		while (i < N)
		{
			if (j < N)
			{
				j++;
				Console.Write("{0} ", j + i);
			}
			else
			{
				i++;
				j = 0;
				Console.WriteLine();
			}
		}
	}
}