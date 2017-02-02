namespace Shapes.Models
{
	class Square: Shape, IShape
	{
		public Square(double side)
			: base(side, side)
		{
		}

		public override double CalculateSurface()
		{
			return (base.Width * base.Height);
		}
	}
}