using System;

class EnglishDigit
{
	static string DigitAsWord(int digit)
	{
		string[] names = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
		return names[digit];
	}

	static void Main()
	{
		int number = int.Parse(Console.ReadLine());

		Console.WriteLine(DigitAsWord(number % 10));
	}
}
