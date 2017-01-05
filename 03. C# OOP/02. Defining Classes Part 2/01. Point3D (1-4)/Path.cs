namespace Point3DTask
{
	using System.Collections.Generic;

	class Path
	{
		private List<Point3D> elements;

		public Path()
		{
			this.elements = new List<Point3D>();
		}
		public Path(IEnumerable<Point3D> collection)
		{
			this.elements = new List<Point3D>(collection);
		}
		public Path(int capacity)
		{
			this.elements = new List<Point3D>(capacity);
		}

		public int Count
		{
			get { return this.elements.Count; }
		}

		public void Add(Point3D element)
		{
			this.elements.Add(element);
		}

		public Point3D this[int index]
		{
			get { return this.elements[index]; }
			set { this.elements[index] = value; }
		}
	}
}