namespace MatrixTask
{
	using System;

	public class TextMatrix
	{
		public static void Main()
		{
			var matrix1 = new Matrix<int>(6, 6);
			for (int i = 0; i < matrix1.Rows; i++)
			{
				for (int j = 0; j < matrix1.Cols; j++)
				{
					matrix1[i, j] = i * j;
				}
			}
			Console.WriteLine(matrix1);

			var matrix2 = new Matrix<int>(6, 6);
			for (int i = 0; i < matrix2.Rows; i++)
			{
				for (int j = 0; j < matrix2.Cols; j++)
				{
					matrix2[i, j] = i + j;
				}
			}
			Console.WriteLine(matrix2);

			Console.WriteLine(matrix1 + matrix2);
		}
	}
}