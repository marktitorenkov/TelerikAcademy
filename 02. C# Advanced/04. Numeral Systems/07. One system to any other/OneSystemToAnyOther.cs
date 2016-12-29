using System;

class Program
{
	static long SToDecimal(string baseSvalue, int baseS)
	{
		long num = 0;

		foreach (char Svalue in baseSvalue)
		{
			int value;
			if (char.IsDigit(Svalue))
				value = Svalue - '0';
			else
				value = Svalue - 'A' + 10;

			num = num * baseS + value;
		}

		return num;
	}

	static string DecimalToD(long num, int baseD)
	{
		string Dvalues = "0123456789ABCDEF";
		string Dresult = string.Empty;

		do
		{
			Dresult = Dvalues[(int)(num % baseD)] + Dresult;
			num /= baseD;
		} while (num > 0);

		return Dresult;
	}

	static void Main()
	{
		int S = int.Parse(Console.ReadLine());
		string numInBaseS = Console.ReadLine();
		int D = int.Parse(Console.ReadLine());

		string numInBaseD = DecimalToD(SToDecimal(numInBaseS, S), D);

		Console.WriteLine(numInBaseD);
	}
}
