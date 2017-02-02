namespace Shapes.Models
{
	class Rectangle: Shape, IShape
	{
		public Rectangle(double width, double height)
			: base(width, height)
		{
		}

		public override double CalculateSurface()
		{
			return (base.Width * base.Height);
		}
	}
}