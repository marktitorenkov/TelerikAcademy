using System;
using System.Linq;

public class SneakyTheSnake
{
	private const int LOSE_WEIGHT_PER_MOVE = 5;

	private static char[,] field;
	private static char[] moves;
	private static int[] pos;
	private static int[] dir = { 1, 0 };
	private static int snakeLength = 3;

	public static void Main()
	{
		int[] size = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
		field = ReadField(size[0], size[1]);
		moves = Console.ReadLine().Split(',').Select(x => x[0]).ToArray();

		string message = "Sneaky is going to be stuck in the den at [{1},{2}]";
		bool canContinue = true;
		for (int i = 0; i < moves.Length && canContinue; i++)
		{
			ExecuteMove(moves[i]);
			snakeLength -= (i != 0 && (i + 1) % LOSE_WEIGHT_PER_MOVE == 0) ? 1 : 0;

			if (snakeLength <= 0)
			{
				message = "Sneaky is going to starve at [{1},{2}]";
				canContinue = false;
				break;
			}

			if (pos[0] >= field.GetLength(0))
			{
				message = "Sneaky is going to be lost into the depths with length {0}";
				canContinue = false;
				break;
			}

			CheckForRightLeftLoop();
			switch (field[pos[0], pos[1]])
			{
				case '-': break;
				case '@':
					snakeLength++;
					field[pos[0], pos[1]] = '.';
					break;
				case '%':
					message = "Sneaky is going to hit a rock at [{1},{2}]";
					canContinue = false;
					break;
				case 'e':
					message = "Sneaky is going to get out with length {0}";
					canContinue = false;
					break;
			}
		}

		Console.WriteLine(message, snakeLength, pos[0], pos[1]);
	}

	private static char[,] ReadField(int rows, int cols)
	{
		char[,] field = new char[rows, cols];

		string line;
		for (int row = 0; row < rows; row++)
		{
			line = Console.ReadLine();
			for (int col = 0; col < cols; col++)
			{
				field[row, col] = line[col];
				if (line[col] == 'e')
				{
					pos = new int[] { row, col };
				}
			}
		}

		return field;
	}

	private static void ExecuteMove(char move)
	{
		switch (move)
		{
			case 's': pos[0]++;
				break;
			case 'w': pos[0]--;
				break;
			case 'd': pos[1]++;
				break;
			case 'a': pos[1]--;
				break;
		}
	}

	private static void CheckForRightLeftLoop()
	{
		if (pos[1] < 0)
		{
			pos[1] = field.GetLength(1) - 1;
		}
		else if (pos[1] >= field.GetLength(1))
		{
			pos[1] = 0;
		}
	}
}