using System;

class HiddenMessage
{
	static void Main()
	{
		string secret = string.Empty;
		while (true)
		{
			int startindex;
			if (!int.TryParse(Console.ReadLine(), out startindex))
				break;
			int skip = int.Parse(Console.ReadLine());
			string text = Console.ReadLine();

			if (startindex < 0)
				startindex = text.Length + startindex;

			for (int i = startindex; i < text.Length && i >= 0; i += skip)
			{
				secret += text[i].ToString();
			}
		}
		Console.WriteLine(secret);
	}
}