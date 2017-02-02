namespace SchoolClasses
{
	using Interfaces;

	abstract public class Person: IPerson, IComentable
	{
		public Person(string name)
		{
			this.Name = name;
		}

		public string Name { get; }
		public string Comment { get; protected set; }
	}
}