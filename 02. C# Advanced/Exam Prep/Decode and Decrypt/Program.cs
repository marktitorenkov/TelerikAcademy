using System;
using System.Text.RegularExpressions;

class Program
{
	static void Main()
	{
		string input = Console.ReadLine();

		string cypherLengthString = GetCypherLength(input);
		int cypherLength = int.Parse(cypherLengthString);

		string encodedMesageAndCypher = input.Remove(input.Length - cypherLengthString.Length);
		string messageAndCypher = Decode(encodedMesageAndCypher);

		string cypher = messageAndCypher.Substring(messageAndCypher.Length - cypherLength);
		string message = messageAndCypher.Remove(messageAndCypher.Length - cypherLength);

		string decryptedMessage = Decrypt(message, cypher);

		Console.WriteLine(decryptedMessage);
	}

	static string GetCypherLength(string input)
	{
		return Regex.Replace(input, "(.*?)([0-9]+$)", "$2");
	}

	static string Decrypt(string message, string cypher)
	{
		char[] result = message.ToCharArray();

		for (int i = 0; i < message.Length || i < cypher.Length; i++)
		{
			int messagei = i % message.Length;
			int cypheri = i % cypher.Length;

			result[messagei] = (char)(((result[messagei] - 'A') ^ (cypher[cypheri] - 'A')) + 'A');
		}

		return string.Join(string.Empty, result);
	}

	static string Decode(string text)
	{
		return Regex.Replace(text, "([0-9]+)(.)", delegate(Match m)
		{
			int count = int.Parse(m.Groups[1].ToString());
			char c = m.Groups[2].ToString()[0];

			return new string(c, count);
		});
	}
}
