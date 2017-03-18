namespace Task2
{
	public class PersonCreator
	{
		public static void Main()
		{
			var creator = new PersonCreator();
			var person = creator.CreatePerson(20);
		}

		public Person CreatePerson(int age)
		{
			var person = new Person();
			person.Age = age;

			if (age % 2 == 0)
			{
				person.Name = "Man";
				person.Sex = Sex.male;
			}
			else
			{
				person.Name = "Woman";
				person.Sex = Sex.female;
			}
			return person;
		}
	}
}
