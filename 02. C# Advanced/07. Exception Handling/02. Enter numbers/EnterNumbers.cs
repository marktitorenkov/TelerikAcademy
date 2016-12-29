using System;
using System.Text;

class Program
{
	static void Main()
	{
		ReadNumbers(1, 100, 10);
	}
	static void ReadNumbers(int start, int end, int count)
	{
		var sb = new StringBuilder(start + " < ");
		int prevnum = start;
		for (int i = 0; i < count; i++)
		{
			try
			{
				int num = int.Parse(Console.ReadLine());
				if (num > prevnum && num < end)
				{
					sb.Append(num + " < ");
					prevnum = num;
				}
				else
				{
					throw new Exception();
				}
			}
			catch (Exception)
			{
				Console.WriteLine("Exception");
				return;
			}

		}
		sb.Append(end);
		Console.WriteLine(sb);
	}
}