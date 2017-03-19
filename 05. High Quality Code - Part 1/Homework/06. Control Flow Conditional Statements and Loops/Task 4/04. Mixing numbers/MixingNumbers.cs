using System;

class MixingNumbers
{
	static void Main()
	{
		int count = int.Parse(Console.ReadLine());

		int[] mixed = new int[count - 1];
		int[] substracted = new int[count - 1];

		string ab = Console.ReadLine();
		for (int i = 0; i < count - 1; i++)
		{
			string cd = Console.ReadLine();

			int b = ab[1] - '0';
			int c = cd[0] - '0';
			mixed[i] = b * c;

			int abNumber = int.Parse(ab);
			int cdNumber = int.Parse(cd);
			substracted[i] = Math.Abs(abNumber - cdNumber);

			ab = cd;
		}

		Console.WriteLine(String.Join(" ", mixed));
		Console.WriteLine(String.Join(" ", substracted));
	}
}
