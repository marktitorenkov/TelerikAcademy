using System;
using System.Text;

class Program
{
	static void Main()
	{
		string text = Console.ReadLine();

		StringBuilder sb = new StringBuilder();
		foreach (char t in text)
		{
			sb.Append(string.Format("\\u{0:X4}", (int)t));
		}
		Console.WriteLine(sb);
	}
}