namespace StudentsAndWorkers.Interfaces
{
	interface IWorker : IHuman
	{
		float WeekSalary { get; }
		float WorkHoursPerDay { get; }
		float MoneyPerHour();
	}
}