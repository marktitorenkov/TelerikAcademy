using System;

class FillТheМatrix
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		char type = Console.ReadLine()[0];

		int[,] matrix = new int[n, n];
		int counter = 1;

		switch (type)
		{
			case 'a':
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						matrix[j, i] = counter++;
					}
				}
				break;
			case 'b':
				for (int i = 0; i < n; i++)
				{
					for (int j = 0; j < n; j++)
					{
						if (i % 2 == 0)
							matrix[j, i] = counter++;
						else
							matrix[n - 1 - j, i] = counter++;
					}
				}
				break;
			case 'c':
				for (int i = 1; i < n; i++)
				{
					for (int j = 0; j < i; j++)
					{
						matrix[n - i + j, j] = counter++;
					}
				}
				for (int i = n; i > 0; i--)
				{
					for (int j = 0; j < i; j++)
					{
						matrix[j, n - i + j] = counter++;
					}
				}
				break;
			case 'd':
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
				break;
		}

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (j == n - 1)
					Console.Write("{0}", matrix[i, j]);
				else
					Console.Write("{0} ", matrix[i, j]);
			}
			Console.WriteLine();
		}
	}
}