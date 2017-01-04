namespace DefiningClassesPart2
{
	using System;

	class Starup
	{
		private const string pathsFileName = "paths.txt";
		private static readonly string pathsFileLocation = Environment.CurrentDirectory + "\\" + pathsFileName;

		static void Main()
		{
			Console.WriteLine("Points:");
			var p1 = new Point3D(5, 3, 8);
			Console.WriteLine($"p1{p1}");

			var p2 = new Point3D(-5, 6, -1);
			Console.WriteLine($"p2{p2}");

			var center = Point3D.Center;
			Console.WriteLine($"O{center}");

			var distance = Distance.Calculcate(p1, p2);
			Console.WriteLine($"\nDistance between p1 and p2: \n{distance:F2}");

			var testPath = new Path(new Point3D[] { p1, p2 });
			testPath.Add(new Point3D(1, 2, 3));
			testPath.Add(new Point3D(12, 7, 9));

			Console.WriteLine("\nPrint test path:");
			for (int i = 0; i < testPath.Count; i++)
			{
				Console.WriteLine(testPath[i]);
			}

			Console.WriteLine($"\nSaving path to file: {pathsFileName}");
			PathStorage.SaveToFile(pathsFileLocation, testPath);

			Console.WriteLine($"\nPrint path loaded from file: {pathsFileName}");
			Path pathFromFile = PathStorage.LoadFromFile(pathsFileLocation);
			for (int i = 0; i < pathFromFile.Count; i++)
			{
				Console.WriteLine(pathFromFile[i]);
			}
		}
	}
}