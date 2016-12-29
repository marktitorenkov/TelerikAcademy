using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		string pattern = Console.ReadLine();
		string text = Console.ReadLine();

		Console.WriteLine(Regex.Matches(text, Regex.Escape(pattern), RegexOptions.IgnoreCase).Count);
	}
}