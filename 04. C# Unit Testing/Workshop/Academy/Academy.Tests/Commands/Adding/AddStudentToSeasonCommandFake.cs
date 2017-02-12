using Academy.Commands.Adding;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.Adding
{
	internal class AddStudentToSeasonCommandFake: AddStudentToSeasonCommand
	{
		internal AddStudentToSeasonCommandFake(IAcademyFactory factory, IEngine engine) : 
			base(factory, engine)
		{
		}

		internal IAcademyFactory Factoy
		{
			get
			{
				return this.factory;
			}
		}

		internal IEngine Engine
		{
			get
			{
				return this.engine;
			}
		}
	}
}
