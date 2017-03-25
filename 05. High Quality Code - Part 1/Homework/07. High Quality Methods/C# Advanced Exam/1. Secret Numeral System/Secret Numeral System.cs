using System;
using System.Numerics;

public class SecretNumeralSystem
{
	public static string ReplaceNames(string original)
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

	public static void Main()
	{
		string input = Console.ReadLine();

		string inputInOct = ReplaceNames(input);

		string[] octNumbers = inputInOct.Split(new string[] { ", " }, StringSplitOptions.None);
		long[] decimalNumbers = new long[octNumbers.Length];
		for (int i = 0; i < octNumbers.Length; i++)
		{
			decimalNumbers[i] = Convert.ToInt64(octNumbers[i].ToString(), 8);
		}

		var product = new BigInteger(1);
		for (int i = 0; i < decimalNumbers.Length; i++)
		{
			product *= decimalNumbers[i];
		}

		Console.WriteLine(product);
	}
}
