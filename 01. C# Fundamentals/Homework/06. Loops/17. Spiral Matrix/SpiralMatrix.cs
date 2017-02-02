using System;

class SpiralMatrix
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[,] matrix = new int[n, n];

		int counter = 1;
		int loop = 0;
		while (counter <= n * n)
		{
			for (int j = loop; j < n - loop; j++)
			{
				matrix[j, loop] = counter++;
			}
			for (int j = loop + 1; j < n - loop; j++)
			{
				matrix[n - 1 - loop, j] = counter++;
			}
			for (int j = n - 2 - loop; j > loop - 1; j--)
			{
				matrix[j, n - 1 - loop] = counter++;
			}
			for (int j = n - 2 - loop; j > loop; j--)
			{
				matrix[loop, j] = counter++;
			}
			loop++;
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				Console.Write("{0} ", matrix[j, i]);
			}
			Console.WriteLine();
		}
	}
}