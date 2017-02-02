namespace StringBuilderSubstring
{
	using System;
	using System.Text;

	class Startup
	{
		static void Main()
		{
			var testSb = new StringBuilder("Test stringbuilder text");
			testSb = testSb.Substring(5);
			testSb = testSb.Substring(0, 13);
			Console.WriteLine(testSb);
		}
	}
}