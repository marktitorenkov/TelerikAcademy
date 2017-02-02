using System;

class MaximalIncreasingSequence
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int sum = 1;
		int maxsum = 1;

		int prevnum = 0;
		for (int i = 0; i < n; i++)
		{
			int num = int.Parse(Console.ReadLine());
			if (num > prevnum)
				sum++;
			else
				sum = 1;

			if (sum > maxsum)
				maxsum = sum;

			prevnum = num;
		}
		Console.WriteLine(maxsum);
	}
}