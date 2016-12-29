using System;

class ReverseNumber
{
	static string Reverse(string num)
	{
		string result = string.Empty;
		for (int i = num.Length - 1; i > -1; i--)
		{
			result += num[i];
		}
		return result;
	}

	static void Main()
	{
		string number = Console.ReadLine();
		Console.WriteLine(Reverse(number));
	}
}
