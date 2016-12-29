using System;
using System.Numerics;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		input = ReplaceNames(input);

		string[] eightNumbers = input.Split(new string[] { ", " }, StringSplitOptions.None);
		long[] decimalNumbers = new long[eightNumbers.Length];

		for (int i = 0; i < eightNumbers.Length; i++)
		{
			decimalNumbers[i] = EightToDecimal(eightNumbers[i]);
		}

		BigInteger product = 1;
		for (int i = 0; i < decimalNumbers.Length; i++)
		{
			product *= decimalNumbers[i];
		}

		Console.WriteLine(product);

	}
	static long EightToDecimal(string baseEightvalue)
	{
		int numBase = 8;
		long num = 0;

		foreach (char ch in baseEightvalue)
		{
			int value;
			if (char.IsDigit(ch))
				value = ch - '0';
			else
				value = ch - 'A' + 10;

			num = num * numBase + value;
		}

		return num;
	}
	static string ReplaceNames(string original)
	{
		return original
			.Replace("hristofor", "3")
			.Replace("hristo", "0")
			.Replace("tosho", "1")
			.Replace("pesho", "2")
			.Replace("vladimir", "7")
			.Replace("vlad", "4")
			.Replace("haralampi", "5")
			.Replace("zoro", "6");
	}
}
