using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		string url = Console.ReadLine();
		Regex pattern = new Regex("(.*?)(://)(.*?)(/)(.*?)($)");

		string protocol = pattern.Match(url).Groups[1].ToString();
		string server = pattern.Match(url).Groups[3].ToString();
		string resources = pattern.Match(url).Groups[5].ToString();

		Console.WriteLine("[protocol] = {0}", protocol);
		Console.WriteLine("[server] = {0}", server);
		Console.WriteLine("[resource] = /{0}", resources);
	}
}