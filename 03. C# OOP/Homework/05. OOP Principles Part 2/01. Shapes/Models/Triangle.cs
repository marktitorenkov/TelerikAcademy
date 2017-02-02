namespace Shapes.Models
{
	class Triangle: Shape, IShape
	{
		public Triangle(double width, double height)
			: base(width, height)
		{
		}

		public override double CalculateSurface()
		{
			return (base.Width * base.Height / 2d);
		}
	}
}