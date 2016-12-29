using System;

class OddOrEven
{
	static void Main()
	{
		int input = int.Parse(Console.ReadLine());

		Console.WriteLine((input % 2 == 0) ? "even " + input : "odd " + input);
	}
}