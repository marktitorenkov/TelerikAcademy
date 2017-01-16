namespace Academy.Models
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Contracts;

	class Lecture: ILecture
	{
		private string name;

		public Lecture(string name, DateTime date, ITrainer trainer)
		{
			this.Name = name;
			this.Date = date;
			this.Trainer = trainer;
			this.Resouces = new List<ILectureResouce>();
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value.Length < 5 || value.Length > 30)
				{
					throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
				}
				this.name = value;
			}
		}

		public DateTime Date { get; set; }

		public ITrainer Trainer { get; set; }

		public IList<ILectureResouce> Resouces { get; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("  * Lecture:");
			sb.AppendLine($"   - Name: {this.Name}");
			sb.AppendLine($"   - Date: {this.Date}");
			sb.AppendLine($"   - Trainer username: {this.Trainer.Username}");
			sb.AppendLine("   - Resources:");
			if (this.Resouces.Count == 0)
			{
				sb.AppendLine("    * There are no resources in this lecture.");
			}
			else
			{
				foreach (var res in this.Resouces)
				{
					sb.AppendLine(res.ToString());
				}
			}
			return sb.ToString();
		}
	}
}
