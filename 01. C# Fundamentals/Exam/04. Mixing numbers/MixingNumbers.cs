using System;

class MixingNumbers
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());

		int[] mixed = new int[n - 1];
		int[] subs = new int[n - 1];

		string ab = Console.ReadLine();
		for (int i = 0; i < n - 1; i++)
		{
			string cd = Console.ReadLine();
			mixed[i] = (ab[1] - '0') * (cd[0] - '0');
			subs[i] = Math.Abs(int.Parse(ab) - int.Parse(cd));
			ab = cd;
		}

		Console.WriteLine(String.Join(" ", mixed));
		Console.WriteLine(String.Join(" ", subs));
	}
}
