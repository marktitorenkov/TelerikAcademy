using System;

class SequenceInMatrix
{
	static void Main()
	{
		string[] line1 = Console.ReadLine().Split(' ');
		int rows = int.Parse(line1[0]);
		int cols = int.Parse(line1[1]);

		// read matrix
		string[,] matrix = new string[rows, cols];
		for (int i = 0; i < rows; i++)
		{
			string[] nline = Console.ReadLine().Split(' ');
			for (int j = 0; j < cols; j++)
			{
				matrix[i, j] = nline[j];
			}
		}

		int max = 1;

		// horizontal lines
		for (int row = 0; row < rows; row++)
		{
			int currmax = 1;
			for (int col = 0; col < cols - 1; col++)
			{
				if (matrix[row, col] == matrix[row, col + 1])
					currmax++;
				else
					currmax = 1;

				if (currmax > max)
					max = currmax;
			}
		}

		// vertical lines
		for (int col = 0; col < cols; col++)
		{
			int currmax = 1;
			for (int row = 0; row < rows - 1; row++)
			{
				if (matrix[row, col] == matrix[row + 1, col])
					currmax++;
				else
					currmax = 1;

				if (currmax > max)
					max = currmax;
			}
		}

		// diagonals by columns
		for (int col = 1; col < cols; col++)
		{
			int currmaxR = 1;
			int currmaxL = 1;
			for (int i = 0; i + 1 < rows && col - i - 1 >= 0; i++)
			{
				// right diagonals
				if (matrix[i, col - i] == matrix[i + 1, col - i - 1])
					currmaxR++;
				else
					currmaxR = 1;
				// left diagonals
				if (matrix[i, cols - 1 - col + i] == matrix[i + 1, cols - col + i])
					currmaxL++;
				else
					currmaxL = 1;

				if (currmaxR > max)
					max = currmaxR;
				if (currmaxL > max)
					max = currmaxL;
			}
		}

		// diagonals by rows
		for (int row = 1; row < rows - 1; row++)
		{
			int currmaxR = 1;
			int currmaxL = 1;
			for (int i = 0; row + i + 1 < rows && cols - i - 2 >= 0; i++)
			{
				// right diagonals
				if (matrix[row + i, cols - 1 - i] == matrix[row + i + 1, cols - i - 2])
					currmaxR++;
				else
					currmaxR = 1;
				// left diagonals
				if (matrix[row + i, i] == matrix[row + i + 1, i + 1])
					currmaxL++;
				else
					currmaxL = 1;

				if (currmaxR > max)
					max = currmaxR;
				if (currmaxL > max)
					max = currmaxL;
			}
		}

		Console.WriteLine(max);
	}
}