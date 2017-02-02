using System;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		int leftcount = 0;
		int rightcount = 0;

		foreach (char i in input)
		{
			if (i == '(')
				leftcount++;
			if (i == ')')
				rightcount++;
		}

		Console.WriteLine(leftcount == rightcount ? "Correct" : "Incorrect");
	}
}