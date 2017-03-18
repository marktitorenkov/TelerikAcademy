using System;
using System.Collections.Generic;

namespace Minesweeper
{
	public class Minesweeper
	{
		public static void Main(string[] args)
		{
			string command = string.Empty;
			char[,] field = CreateField();
			char[,] mines = PlaceBombs();
			int counter = 0;
			bool gameLost = false;
			var highScores = new List<HighScore>(6);
			int row = 0;
			int col = 0;
			bool showGreeting = true;
			const int maxMinesCount = 35;
			bool gameWon = false;

			do
			{
				if (showGreeting)
				{
					Console.WriteLine("Let's play Minesweeper. Try your luck. " +
					"The command 'top' shows the scoreboard, 'restart' starts a new game, 'exit' quits the game!");
					PrintField(field);
					showGreeting = false;
				}

				Console.Write("Enter row and column: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
						int.TryParse(command[2].ToString(), out col) &&
						row <= field.GetLength(0) && col <= field.GetLength(1))
					{
						command = "turn";
					}
				}

				switch (command)
				{
					case "top":
						PrintHighScores(highScores);
						break;
					case "restart":
						field = CreateField();
						mines = PlaceBombs();
						PrintField(field);
						gameLost = false;
						showGreeting = false;
						break;
					case "exit":
						Console.WriteLine("bye, bye, bye!");
						break;
					case "turn":
						if (mines[row, col] != '*')
						{
							if (mines[row, col] == '-')
							{
								NextTurn(field, mines, row, col);
								counter++;
							}
							if (maxMinesCount == counter)
							{
								gameWon = true;
							}
							else
							{
								PrintField(field);
							}
						}
						else
						{
							gameLost = true;
						}
						break;
					default:
						Console.WriteLine("\nError! Inalid Command\n");
						break;
				}
				if (gameLost)
				{
					PrintField(mines);

					Console.Write($"\nOooo! You died like a hero with {counter} points. Type your nickname: ");
					string nickname = Console.ReadLine();
					var score = new HighScore(nickname, counter);

					if (highScores.Count < 5)
					{
						highScores.Add(score);
					}
					else
					{
						for (int i = 0; i < highScores.Count; i++)
						{
							if (highScores[i].Score < score.Score)
							{
								highScores.Insert(i, score);
								highScores.RemoveAt(highScores.Count - 1);
								break;
							}
						}
					}

					highScores.Sort((HighScore r1, HighScore r2) => r2.Name.CompareTo(r1.Name));
					highScores.Sort((HighScore r1, HighScore r2) => r2.Score.CompareTo(r1.Score));
					PrintHighScores(highScores);

					field = CreateField();
					mines = PlaceBombs();
					counter = 0;
					gameLost = false;
					showGreeting = true;
				}
				if (gameWon)
				{
					Console.WriteLine("\nWELL DONE! You oppened 35 boxes without a drop of blood!");
					PrintField(mines);
					Console.WriteLine("Type your nickname, batka: ");
					string nickName = Console.ReadLine();
					var score = new HighScore(nickName, counter);
					highScores.Add(score);

					PrintHighScores(highScores);
					field = CreateField();
					mines = PlaceBombs();
					counter = 0;
					gameWon = false;
					showGreeting = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void PrintHighScores(List<HighScore> highScores)
		{
			Console.WriteLine("\nHigh Scores:");
			if (highScores.Count > 0)
			{
				for (int i = 0; i < highScores.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} boxes",
						i + 1, highScores[i].Name, highScores[i].Score);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("Empty!\n");
			}
		}

		private static void NextTurn
			(char[,] field, char[,] bombs, int row, int col)
		{
			char kolkoBombi = CoutnSurroundigBombs(bombs, row, col);
			bombs[row, col] = kolkoBombi;
			field[row, col] = kolkoBombi;
		}

		private static void PrintField(char[,] field)
		{
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < rows; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < cols; j++)
				{
					Console.Write(string.Format("{0} ", field[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateField()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] PlaceBombs()
		{
			int rows = 5;
			int cols = 10;
			char[,] field = new char[rows, cols];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					field[i, j] = '-';
				}
			}

			var bombs = new List<int>();
			while (bombs.Count < 15)
			{
				var randomGen = new Random();
				int currRnd = randomGen.Next(50);
				if (!bombs.Contains(currRnd))
				{
					bombs.Add(currRnd);
				}
			}

			foreach (int bomb in bombs)
			{
				int col = (bomb / cols);
				int row = (bomb % cols);
				if (row == 0 && bomb != 0)
				{
					col--;
					row = cols;
				}
				else
				{
					row++;
				}
				field[col, row - 1] = '*';
			}

			return field;
		}

		private static void ShowSurroundingBombsCount(char[,] field)
		{
			int cols = field.GetLength(0);
			int rows = field.GetLength(1);

			for (int r = 0; r < cols; r++)
			{
				for (int c = 0; c < rows; c++)
				{
					if (field[r, c] != '*')
					{
						char suroundingBombsCount = CoutnSurroundigBombs(field, r, c);
						field[r, c] = suroundingBombsCount;
					}
				}
			}
		}

		private static char CoutnSurroundigBombs(char[,] field, int row, int col)
		{
			int count = 0;
			int rows = field.GetLength(0);
			int cols = field.GetLength(1);

			if (row - 1 >= 0)
			{
				if (field[row - 1, col] == '*')
				{
					count++;
				}
			}
			if (row + 1 < rows)
			{
				if (field[row + 1, col] == '*')
				{
					count++;
				}
			}
			if (col - 1 >= 0)
			{
				if (field[row, col - 1] == '*')
				{
					count++;
				}
			}
			if (col + 1 < cols)
			{
				if (field[row, col + 1] == '*')
				{
					count++;
				}
			}
			if ((row - 1 >= 0) && (col - 1 >= 0))
			{
				if (field[row - 1, col - 1] == '*')
				{
					count++;
				}
			}
			if ((row - 1 >= 0) && (col + 1 < cols))
			{
				if (field[row - 1, col + 1] == '*')
				{
					count++;
				}
			}
			if ((row + 1 < rows) && (col - 1 >= 0))
			{
				if (field[row + 1, col - 1] == '*')
				{
					count++;
				}
			}
			if ((row + 1 < rows) && (col + 1 < cols))
			{
				if (field[row + 1, col + 1] == '*')
				{
					count++;
				}
			}
			return char.Parse(count.ToString());
		}
	}
}
