using System;

class FourDigits
{
	static void Main()
	{
		string n = Console.ReadLine();

		int sum = 0;
		string reversed= string.Empty;
		for (int i = 0; i < n.Length; i++)
		{
			sum += int.Parse(n[i].ToString());
			reversed += n[n.Length - 1 - i];
		}
		string firstLast = n[3].ToString() + n[0] + n[1] + n[2];
		string secondThird = n[0].ToString() + n[2] + n[1] + n[3];

		Console.WriteLine(sum);
		Console.WriteLine(reversed);
		Console.WriteLine(firstLast);
		Console.WriteLine(secondThird);
	}
}