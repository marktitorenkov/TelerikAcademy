namespace LongestString
{
	using System;
	using System.Linq;

	class Startup
	{
		static void Main()
		{
			string[] strings = new string[] { "Meme", "Neshto drugo", "Neshto", "Orgomen string e tova", "Neshtobaqdulgo", "Ne dostatuchno dulug string", "Eto tova e nai dulgiq string, koito trqbva da vurne programata :)" };

			var longest = (from str in strings orderby str.Length descending select str).First();

			Console.WriteLine(longest);
		}
	}
}