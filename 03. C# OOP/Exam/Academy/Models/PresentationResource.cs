namespace Academy.Models
{
	using System.Text;
	using Contracts;
	using Enums;

	public class PresentationResource: LectureResource, ILectureResouce
	{
		public PresentationResource(string name, string url)
			:base(name, url, ResourceType.Presentation)
		{
		}
	}
}