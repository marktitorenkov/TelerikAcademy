namespace Academy.Models
{
	using Contracts;
	using Enums;

	public class DemoResource: LectureResource, ILectureResouce
	{
		public DemoResource(string name, string url)
			:base(name, url, ResourceType.Demo)
		{
		}
	}
}