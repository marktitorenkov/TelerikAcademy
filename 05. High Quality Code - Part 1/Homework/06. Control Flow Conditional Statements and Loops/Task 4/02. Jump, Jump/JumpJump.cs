using System;

public class JumpJump
{
	public static void Main()
	{
		string directions = Console.ReadLine();

		int position = 0;
		while (true)
		{
			if (position >= 0 && position < directions.Length)
			{
				char charAtPosition = directions[position];
				int digitAtPosition = charAtPosition - '0';

				if (charAtPosition == '0')
				{
					Console.WriteLine($"Too drunk to go on after {position}!");
					break;
				}

				if (charAtPosition == '^')
				{
					Console.WriteLine($"Jump, Jump, DJ Tomekk kommt at {position}!");
					break;
				}
				else if (digitAtPosition % 2 == 0)
				{
					position += digitAtPosition;
				}
				else if (digitAtPosition % 2 == 1)
				{
					position -= digitAtPosition;
				}
			}
			else
			{
				Console.WriteLine($"Fell off the dancefloor at {position}!");
				break;
			}
		}
	}
}
