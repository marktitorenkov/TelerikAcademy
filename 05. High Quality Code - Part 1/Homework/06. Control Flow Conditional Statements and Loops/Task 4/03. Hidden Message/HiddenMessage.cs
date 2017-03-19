using System;

class HiddenMessage
{
	static void Main()
	{
		string secretMessage = string.Empty;

		while (true)
		{
			int startindex;
			// If the line is not a number it must be 'end'
			if (!int.TryParse(Console.ReadLine(), out startindex))
			{
				break;
			}

			int symbolsToSkip = int.Parse(Console.ReadLine());
			string subtitleText = Console.ReadLine();

			if (startindex < 0)
			{
				startindex = subtitleText.Length + startindex;
			}

			for (int i = startindex; i < subtitleText.Length && i >= 0; i += symbolsToSkip)
			{
				secretMessage += subtitleText[i].ToString();
			}
		}

		Console.WriteLine(secretMessage);
	}
}
