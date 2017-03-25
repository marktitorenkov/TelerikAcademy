using System;
using System.Collections.Generic;
using System.Numerics;

namespace GoshoCode
{
	public class GoshoCode
	{
		public static void Main()
		{
			string word = Console.ReadLine();
			int linesCount = int.Parse(Console.ReadLine());
			var lines = new List<string>();
			for (int line = 0; line < linesCount; line++)
			{
				lines.Add(Console.ReadLine());
			}

			string text = string.Join(" ", lines);

			int wordIndex = text.IndexOf(word);
			int sentanceBegining = -1;
			for (int index = wordIndex; index > 0; index--)
			{
				if (text[index] >= 65 && text[index] <= 90)
				{
					sentanceBegining = index;
					break;
				}
			}

			string targetSubstring = string.Empty;
			for (int index = wordIndex + word.Length; index < text.Length; index++)
			{
				if (text[index] == '.')
				{
					var sentanceEnd = index;
					targetSubstring = text.Substring(wordIndex + word.Length, sentanceEnd - (wordIndex + word.Length));
					break;
				}

				if (text[index] == '!')
				{
					var sentanceEnd = index;
					targetSubstring = text.Substring(sentanceBegining, wordIndex - sentanceBegining);
					break;
				}
			}

			string gluedSubstring = targetSubstring.Replace(" ", string.Empty);
			BigInteger result = 0;
			foreach (var character in gluedSubstring)
			{
				result += character * word.Length;
			}

			Console.WriteLine(result);
		}
	}
}
