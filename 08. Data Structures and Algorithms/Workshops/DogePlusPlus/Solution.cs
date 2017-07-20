using System;
using System.Numerics;

namespace DogePlusPlus
{
	class Program
	{
		static void Main()
		{
			var strs = Console.ReadLine().Split(' ');
			int rows = int.Parse(strs[0]);
			int cols = int.Parse(strs[1]);
			int k = int.Parse(strs[2]);

			var coordinates = Console.ReadLine()
				.Split("; ".ToCharArray());

			var wall = new bool[rows, cols];
			for (int i = 0; i < coordinates.Length; i += 2)
			{
				int row = int.Parse(coordinates[i]);
				int col = int.Parse(coordinates[i + 1]);
				wall[row, col] = true;
			}

			var field = new BigInteger[rows, cols, k + 1];
			field[0, 0, 0] = 1;
			for (int l = 0; l <= k; l++)
			{
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < cols; j++)
					{
						if (wall[i, j])
						{
							continue;
						}

						if (i > 0)
						{
							field[i, j, l] += field[i - 1, j, l];
						}
						if (j > 0)
						{
							field[i, j, l] += field[i, j - 1, l];
						}

						if (l > 0)
						{
							if (i < rows - 1)
							{
								field[i, j, l] += field[i + 1, j, l - 1];
							}
							if (j < cols - 1)
							{
								field[i, j, l] += field[i, j + 1, l - 1];
							}
						}
					}
				}
			}

			BigInteger total = 0;
			for (int i = 0; i < k + 1; i++)
			{
				total += field[rows - 1, cols - 1, i];
			}

			Console.WriteLine(total);
		}
	}
}