namespace Academy.Commands.Listing
{
	using System;
	using Contracts;
	using Core.Contracts;
	using System.Collections.Generic;
	using System.Text;

	class ListUsersCommand : ICommand
	{
		private readonly IAcademyFactory factory;
		private readonly IEngine engine;

		public ListUsersCommand(IAcademyFactory factory, IEngine engine)
		{
			this.factory = factory;
			this.engine = engine;
		}

		public string Execute(IList<string> parameters)
		{
			var trainers = this.engine.Trainers;
			var studnets = this.engine.Students;

			var sb = new StringBuilder();

			if (trainers.Count == 0 && studnets.Count == 0)
			{
				throw new Exception("There are no registered users!");
			}

			if (trainers.Count != 0)
			{
				foreach (var trainer in trainers)
				{
					sb.AppendLine(trainer.ToString().Trim());
				}
			}
			if (studnets.Count != 0)
			{
				foreach (var student in studnets)
				{
					sb.AppendLine(student.ToString().Trim());
				}
			}
			return sb.ToString();
		}
	}
}
