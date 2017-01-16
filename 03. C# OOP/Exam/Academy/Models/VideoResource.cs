namespace Academy.Models
{
	using System;
	using Contracts;
	using Enums;

	class VideoResource : LectureResource, ILectureResouce
	{
		public VideoResource(string name, string url, DateTime now)
			: base(name, url, ResourceType.Video)
		{
			this.UploadedOn = now;
		}
		public DateTime UploadedOn { get; }

		public override string ToString()
		{
			return base.ToString() + $"     - Uploaded on: {this.UploadedOn}";
		}
	}
}