namespace Point3DTask
{
	using System;
	using System.IO;
	using System.Text;

	static class PathStorage
	{
		public static Path LoadFromFile(string filePath)
		{
			string fileStr = File.ReadAllText(filePath);

			string[] pointsStr = fileStr.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			Path path = new Path();
			for (int i = 0; i < pointsStr.Length; i++)
			{
				Point3D point = Point3D.Parse(pointsStr[i]);
				path.Add(point);
			}
			return path;
		}
		public static void SaveToFile(string savelocation, Path path)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < path.Count; i++)
			{
				sb.Append(path[i].ToString());
				sb.Append(';');
			}
			File.WriteAllText(savelocation, sb.ToString());
		}
	}
}