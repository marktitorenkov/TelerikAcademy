using System;
using System.Text;

class Program
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		long mask = 1;
		long all = 0;
		long allOdd = 0;

		for (int i = 0; i < n; i++)
		{
			long num = long.Parse(Console.ReadLine());
			all |= num;
			allOdd ^= num;
		}

		if (all == 4503599627370495)
			Console.WriteLine("Full deck");
		else
			Console.WriteLine("Wa wa!");

		var oddValues = new StringBuilder();
		string cardTypes = "cdhs";
		string cardValues = "23456789TJQKA";

		for (int i = 0; i < 52; i++)
		{
			char cardType = cardTypes[i / 13];
			char cardValue = cardValues[i % 13];

			if ( ((allOdd & (mask << i)) >> i) == 1 )
			{
				oddValues.Append(cardValue).Append(cardType).Append(" ");
			}

		}
		Console.WriteLine(oddValues);
	}
}