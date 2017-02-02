namespace Shapes.Models
{
	abstract class Shape: IShape
	{
		private double width;
		private double height;

		public Shape(double width, double height)
		{
			this.width = width;
			this.height = height;
		}

		public double Width
		{
			get { return this.width; }
			private set { this.width = value; }
		}
		public double Height
		{
			get { return this.height; }
			private set { this.height = value; }
		}

		public abstract double CalculateSurface();
	}
}