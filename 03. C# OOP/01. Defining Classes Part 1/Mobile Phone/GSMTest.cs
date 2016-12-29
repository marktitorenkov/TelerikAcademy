using System;

public class GSMTest
{
	public static void Start()
	{
		GSM[] GSMArray = 
		{
			GSM.iPhone4s,
			new GSM("Samsung", "Galaxy S3 Neo", 300, "Tosho", "Removable", 210, 9, BatteryType.LiIon, 4f, 16), 
			new GSM("Nokia", "100", null, "Gosho", "Removable", int.MaxValue, (int)(int.MaxValue * 0.5), BatteryType.NiMH, 2.5f, 4),
			new GSM("Motorola", "Moto G3", 350, null, null) // partial exaple
		};

		foreach (var gsm in GSMArray)
		{
			Console.WriteLine(new string('-', 30));
			Console.WriteLine(gsm);
		}
	}
}