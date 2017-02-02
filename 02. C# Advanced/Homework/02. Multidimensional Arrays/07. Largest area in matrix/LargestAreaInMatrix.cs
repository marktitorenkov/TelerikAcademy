using System;

class Matrix
{
	public static int[,] ReadFromConsole(int rows, int cols)
	{
		int[,] matrix = new int[rows, cols];
		for (int row = 0; row < rows; row++)
		{
			string[] line = Console.ReadLine().Split(' ');
			for (int col = 0; col < cols; col++)
			{
				matrix[row, col] = int.Parse(line[col]);
			}
		}
		return matrix;
	}

	public static void WriteToConsole(int[,] matrix, int padding = 4)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				Console.Write("{0} ", matrix[row, col]);
			}
			Console.WriteLine();
		}
	}
}

class LargestAreaInMatrix
{
	static void Main()
	{
		string[] line1 = Console.ReadLine().Split(' ');
		int rows = int.Parse(line1[0]);
		int cols = int.Parse(line1[1]);
		int[,] matrix = Matrix.ReadFromConsole(rows, cols);



		Matrix.WriteToConsole(matrix);
	}
}