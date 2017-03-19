using System;

namespace Task1
{
	public class Size
	{
		public Size(double width, double height)
		{
			this.Width = width;
			this.Height = height;
		}
		public double Width { get; set; }
		public double Height { get; set; }

		public static Size GetRotatedSize(Size originalSize, double angle)
		{
			double cos = Math.Abs(Math.Cos(angle));
			double sin = Math.Abs(Math.Sin(angle));

			double rotaedWidth = (cos * originalSize.Width) + (sin * originalSize.Height);
			double rotatedHeight = (sin * originalSize.Width) + (cos * originalSize.Height);

			return new Size(rotaedWidth, rotatedHeight);
		}
	}
}
