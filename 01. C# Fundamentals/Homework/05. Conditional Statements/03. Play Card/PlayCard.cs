using System;

class PlayCard
{
	static void Main()
	{
		string[] cards = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

		string input = Console.ReadLine();

		bool iscard = false;
		for (int i = 0; i < cards.Length; i++)
		{
			if (cards[i] == input)
			{
				iscard = true;
				break;
			}
		}
		Console.WriteLine("{0} {1}", iscard ? "yes" : "no", input);
	}
}
