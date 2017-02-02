using System;

class GetLargestNumber
{
	static int GetMax(int a, int b)
	{
		if (a > b)
			return a;
		else
			return b;
	}

	static void Main()
	{
		string[] input = Console.ReadLine().Split(' ');
		int a = int.Parse(input[0]);
		int b = int.Parse(input[1]);
		int c = int.Parse(input[2]);

		Console.WriteLine(GetMax(GetMax(a, b), c));
	}
}
