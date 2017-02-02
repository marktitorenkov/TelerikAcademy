namespace Shapes.Models
{
	interface IShape
	{
		double Width { get; }
		double Height { get; }
		double CalculateSurface();
	}
}