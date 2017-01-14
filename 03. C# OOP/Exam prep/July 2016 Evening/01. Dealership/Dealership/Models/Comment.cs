namespace Dealership.Models
{
	using System.Text;
	using Common;
	using Contracts;

	class Comment: IComment
	{
		private string content;

		public Comment(string content)
		{
			this.Content = content;
		}

		public string Author { get; set; }

		public string Content
		{
			get { return this.content; }
			private set
			{
				Validator.ValidateIntRange(value.Length, Constants.MinCommentLength, Constants.MaxCommentLength,
					string.Format(Constants.StringMustBeBetweenMinAndMax, "Content", Constants.MinCommentLength, Constants.MaxCommentLength));
				this.content = value;
			}
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("\n    " + new string('-', 10));
			sb.Append("\n    " + this.Content);
			sb.Append("\n      User: " + this.Author);
			sb.Append("\n    " + new string('-', 10));
			return sb.ToString();
		}
	}
}