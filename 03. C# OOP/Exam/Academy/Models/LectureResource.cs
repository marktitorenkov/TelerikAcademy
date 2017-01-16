namespace Academy.Models
{
	using System;
	using System.Text;
	using Contracts;
	using Enums;

	public abstract class LectureResource: ILectureResouce
	{
		private string name;
		private string url;

		public LectureResource(string name, string url, ResourceType type)
		{
			this.Name = name;
			this.Url = url;
			this.Type = type;
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (value.Length < 3 || value.Length > 15)
				{
					throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
				}
				this.name = value;
			}
		}

		public string Url
		{
			get { return this.url; }
			set
			{
				if (value.Length < 5 || value.Length > 150)
				{
					throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
				}
				this.url = value;
			}
		}

		public ResourceType Type { get; }

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("    * Resource:");
			sb.AppendLine($"     - Name: {this.Name}");
			sb.AppendLine($"     - Url: {this.Url}");
			sb.AppendLine($"     - Type: {this.Type}");
			return sb.ToString();
		}
	}
}