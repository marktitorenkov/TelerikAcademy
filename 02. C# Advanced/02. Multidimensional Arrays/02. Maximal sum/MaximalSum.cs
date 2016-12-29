using System;

class MaximalSum
{
	static void Main()
	{
		string[] line1 = Console.ReadLine().Split(' ');
		int n = int.Parse(line1[0]);
		int m = int.Parse(line1[1]);
		int k = 3;

		int[,] matrix = new int[n, m];
		for (int i = 0; i < n; i++)
		{
			string[] nline = Console.ReadLine().Split(' ');
			for (int j = 0; j < m; j++)
			{
				matrix[i, j] = int.Parse(nline[j]);
			}
		}

		int maxsum = int.MinValue;
		for (int startn = 0; startn < n - k + 1; startn++)
		{
			for (int startm = 0; startm < m - k + 1; startm++)
			{
				int currsum = 0;
				for (int i = startn; i < startn + k; i++)
				{
					for (int j = startm; j < startm + k; j++)
					{
						currsum += matrix[i, j];
					}
				}
				if (currsum > maxsum)
					maxsum = currsum;
			}
		}
		Console.WriteLine(maxsum);
	}
}