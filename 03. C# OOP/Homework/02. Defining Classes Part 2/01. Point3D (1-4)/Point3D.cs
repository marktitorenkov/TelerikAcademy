namespace Point3DTask
{
	using System;
	using System.Linq;

	class Point3D
	{
		private static readonly Point3D center = new Point3D(0, 0, 0);

		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }

		public static Point3D Center
		{
			get { return center; }
		}

		public Point3D(double x, double y, double z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public static Point3D Parse(string pointstring)
		{
			double[] pointCords = pointstring.Split(",()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
			return new Point3D(pointCords[0], pointCords[1], pointCords[2]);
		}

		public override string ToString()
		{
			return $"({this.X},{this.Y},{this.Z})";
		}
	}
}