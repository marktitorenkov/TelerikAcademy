namespace MatrixTask
{
	using System;
	using System.Text;

	public class Matrix<T>
	{
		private T[,] matrix;

		public Matrix(int rows, int cols)
		{
			this.Rows = rows;
			this.Cols = cols;
			this.matrix = new T[rows, cols];
		}

		public int Rows { get; }
		public int Cols { get; }

		public T this[int row, int col]
		{
			get { return this.matrix[row, col]; }
			set { this.matrix[row, col] = value; }
		}

		public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
			{
				throw new ArgumentException();
			}
			var newMatrix = new Matrix<T>(matrix1.Rows, matrix2.Rows);
			for (int r = 0; r < matrix1.Rows; r++)
			{
				for (int c = 0; c < matrix2.Cols; c++)
				{
					newMatrix[r, c] = (dynamic)matrix1[r, c] + matrix2[r, c];
				}
			}
			return newMatrix;
		}
		public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
			{
				throw new ArgumentException();
			}
			var newMatrix = new Matrix<T>(matrix1.Rows, matrix2.Rows);
			for (int r = 0; r < matrix1.Rows; r++)
			{
				for (int c = 0; c < matrix2.Cols; c++)
				{
					newMatrix[r, c] = (dynamic)matrix1[r, c] - matrix2[r, c];
				}
			}
			return newMatrix;
		}
		public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			if (matrix1.Rows != matrix2.Rows || matrix1.Cols != matrix2.Cols)
			{
				throw new ArgumentException();
			}
			var newMatrix = new Matrix<T>(matrix1.Rows, matrix2.Rows);
			for (int r = 0; r < matrix1.Rows; r++)
			{
				for (int c = 0; c < matrix2.Cols; c++)
				{
					newMatrix[r, c] = (dynamic)matrix1[r, c] * matrix2[r, c];
				}
			}
			return newMatrix;
		}
		public static bool operator true(Matrix<T> matrix)
		{
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Cols; c++)
				{
					if (!matrix[r, c].Equals(default(T)))
					{
						return true;
					}
				}
			}
			return false;
		}
		public static bool operator false(Matrix<T> matrix)
		{
			for (int r = 0; r < matrix.Rows; r++)
			{
				for (int c = 0; c < matrix.Cols; c++)
				{
					if (!matrix[r, c].Equals(default(T)))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			for (int r = 0; r < this.Rows; r++)
			{
				for (int c = 0; c < this.Cols; c++)
				{
					sb.Append(matrix[r, c]).ToString();
					sb.Append(' ');
				}
				sb.Append(Environment.NewLine);
			}
			return sb.ToString();
		}
	}
}