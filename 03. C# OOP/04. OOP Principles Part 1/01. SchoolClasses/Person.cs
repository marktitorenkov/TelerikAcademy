namespace SchoolClasses
{
	abstract public class Person: IComentable
	{
		public Person(string name)
		{
			this.Name = name;
		}

		public string Name { get; }

		public string Comment { get; set; }
	}
}