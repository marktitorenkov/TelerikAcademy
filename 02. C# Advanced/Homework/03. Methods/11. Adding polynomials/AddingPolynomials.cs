using System;

class AddingPolynomials
{
	static int[] IntArrFromStr(string str)
	{
		string[] strarr = str.Split(' ');
		int[] arr = new int[strarr.Length];
		for (int i = 0; i < strarr.Length; i++)
		{
			arr[i] = int.Parse(strarr[i]);
		}
		return arr;
	}

	static int[] AddPolynomials(int[] poly1, int[] poly2, int length)
	{
		int[] sum = new int[length];

		for (int i = 0; i < length; i++)
		{
			sum[i] = poly1[i] + poly2[i]; 
		}

		return sum;
	}

	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int[] poly1 = IntArrFromStr(Console.ReadLine());
		int[] poly2 = IntArrFromStr(Console.ReadLine());

		int[] sum = AddPolynomials(poly1, poly2, n);

		Console.WriteLine(string.Join(" ", sum));
	}
}
