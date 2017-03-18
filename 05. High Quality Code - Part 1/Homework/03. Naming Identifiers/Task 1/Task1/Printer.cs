using System;

namespace Task1
{
	internal class Printer
	{
		internal void PrintBoolValue(bool boolValue)
		{
			string boolString = boolValue.ToString();
			Console.WriteLine(boolString);
		}
	}
}
