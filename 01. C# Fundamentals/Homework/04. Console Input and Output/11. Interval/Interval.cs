using System;

class Interval
{
	static void Main()
	{
		int N = int.Parse(Console.ReadLine());
		int M = int.Parse(Console.ReadLine());

		int amount = 0;
		for (int i = N + 1; i < M; i++)
		{
			if (i % 5 == 0)
				amount++;
		}

		Console.WriteLine(amount);
	}
}
