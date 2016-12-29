using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		string text = Console.ReadLine();
		string pattern = @"(<upcase>)(.*?)(</upcase>)";

		Console.WriteLine( Regex.Replace(text, pattern, Upper) );
	}
	static string Upper(Match m)
	{
		return m.Groups[2].ToString().ToUpper();
	}
}