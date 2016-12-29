using System;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		Console.WriteLine(Reverse(input));
	}
	static string Reverse(string str)
	{
		char[] chars = str.ToCharArray();
		Array.Reverse(chars);
		return new string(chars);
	}
}