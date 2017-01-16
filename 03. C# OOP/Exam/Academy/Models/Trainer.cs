namespace Academy.Models
{
	using System.Collections.Generic;
	using System.Text;
	using Contracts;

	public class Trainer: User, ITrainer, IUser
	{
		public Trainer(string username, IList<string> technologies)
			:base(username)
		{
			this.Technologies = technologies;
		}

		public IList<string> Technologies { get; set; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("* Trainer:");
			sb.AppendLine($" - Username: {this.Username}");
			sb.Append($" - Technologies: ");
			sb.Append(string.Join("; ", this.Technologies).Trim());
			return sb.ToString();
		}
	}
}