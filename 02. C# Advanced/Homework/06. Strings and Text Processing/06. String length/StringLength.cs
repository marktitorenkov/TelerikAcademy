using System;

class Program
{
	static void Main()
	{
		string text = Console.ReadLine();

		Console.WriteLine(text.PadRight(20, '*'));
	}
}