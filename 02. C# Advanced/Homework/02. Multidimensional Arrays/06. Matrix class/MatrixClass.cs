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

	public static void WriteToConsole(int[,] matrix)
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

	public static int[,] Sum(int[,] matrix1, int[,] matrix2)
	{
		int rows = matrix1.GetLength(0);
		int cols = matrix1.GetLength(1);
		int[,] result = new int[rows, cols];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				result[row, col] = matrix1[row, col] + matrix2[row, col];
			}
		}
		return result;
	}

	public static int[,] Multiply(int[,] matrix1, int[,] matrix2)
	{
		int rows = matrix1.GetLength(0);
		int cols = matrix1.GetLength(1);
		int[,] result = new int[rows, cols];
		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				result[row, col] = matrix1[row, col] * matrix2[row, col];
			}
		}
		return result;
	}

	public static string ToString(int[,] matrix)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		string result = string.Empty;
		string seperator = ", ";
		for (int row = 0; row < rows; row++)
		{
			result += "{ ";
			for (int col = 0; col < cols; col++)
			{
				if (col != cols - 1)
					result += matrix[row, col] + seperator;
				else
					result += matrix[row, col];
			}
			if (row != rows - 1)
				result += " }" + seperator;
			else
				result += " }";
		}
		return result;
	}
}

class MatrixClass
{
	static void Main()
	{
		string seperator = new string('=', 50);

		Console.Write("Enter number of matrix rows: ");
		int rows = int.Parse(Console.ReadLine());
		Console.Write("Enter number of matrix columns: ");
		int cols = int.Parse(Console.ReadLine());

		Console.WriteLine(seperator);

		Console.WriteLine("Enter MATRIX1: ");
		int[,] matrix1 = Matrix.ReadFromConsole(rows, cols);

		Console.WriteLine(seperator);

		Console.WriteLine("Enter MATRIX2: ");
		int[,] matrix2 = Matrix.ReadFromConsole(rows, cols);

		Console.WriteLine(seperator);

		Console.WriteLine("The summed matrix is: ");
		Matrix.WriteToConsole(Matrix.Sum(matrix1, matrix2));

		Console.WriteLine(seperator);

		Console.WriteLine("The multiplied matrix is: ");
		Matrix.WriteToConsole(Matrix.Multiply(matrix1, matrix2));

		Console.WriteLine(seperator);

		Console.WriteLine("ToString() method on MATRIX1: ");
		Console.WriteLine(Matrix.ToString(matrix1));

		Console.WriteLine(seperator);

		Console.WriteLine("ToString() method on MATRIX2: ");
		Console.WriteLine(Matrix.ToString(matrix2));
	}
}