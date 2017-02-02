using System;
using System.Text.RegularExpressions;

class ReplaceTags
{
	static void Main()
	{
		string input = Console.ReadLine();
		string pattern = @"(<a href="")(.*?)("">)(.*?)(</a>)";

		Console.WriteLine( Regex.Replace(input, pattern, "[$4]($2)") );
	}
}