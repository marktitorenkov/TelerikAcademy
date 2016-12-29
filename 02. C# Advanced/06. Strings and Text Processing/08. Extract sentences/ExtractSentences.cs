using System;
using System.Text;

class Program
{
	static void Main()
	{
		string searchword = Console.ReadLine();
		string text = Console.ReadLine();

		Console.WriteLine(SentContainingWord(searchword, text));
	}

	static string SentContainingWord(string searchword, string text)
	{
		string[] sentances = text.Split('.');
		StringBuilder result = new StringBuilder();
		foreach (string sentence in sentances)
		{
			StringBuilder nonletters = new StringBuilder();
			foreach (char s in sentence)
			{
				if (!char.IsLetter(s))
					nonletters.Append(s);
			}
			char[] nonlettersArr = nonletters.ToString().ToCharArray();

			string[] words = sentence.Split(nonlettersArr, StringSplitOptions.RemoveEmptyEntries);

			foreach (string word in words)
			{
				if (word == searchword)
				{
					result.Append(sentence.Trim() + ". ");
					break;
				}
			}
		}
		return result.ToString();
	}
}