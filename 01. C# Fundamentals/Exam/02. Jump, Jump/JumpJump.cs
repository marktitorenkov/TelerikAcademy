using System;

class JumpJump
{
	static void Main()
	{
		string dir = Console.ReadLine();

		int p = 0;
		while (true)
		{
			if (p >= 0 && p < dir.Length)
			{
				char cvalue = dir[p];
				int value = cvalue - '0';
				if (value == 0)
				{
					Console.WriteLine("Too drunk to go on after {0}!", p);
					break;
				}
				if (cvalue == '^')
				{
					Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", p);
					break;
				}
				else if (value % 2 == 0)
				{
					p += value;
				}
				else if (value % 2 == 1)
				{
					p -= value;
				}
			}
			else
			{
				Console.WriteLine("Fell off the dancefloor at {0}!", p);
				break;
			}
		}
	}
}