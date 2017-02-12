using NUnit.Framework;
using Academy.Core.Factories;
using System;
using Academy.Models.Utils.LectureResources;

namespace Academy.Tests.Core.Factories.AcademyFactoryTests
{
	[TestFixture]
	public class AcademyFactoryCreateLectureResource_Should
	{
		[Test]
		public void ThrowArgumentException_WhenPassedTypeIsInvalid()
		{
			// Arrange
			var factory = AcademyFactory.Instance;

			// Act & Assert
			Assert.Throws<ArgumentException>(() =>
			{
				factory.CreateLectureResource("invalid type", "valid name", "http://validurl.com/");
			});
		}

		[Test]
		public void ReturnVideoResource_WhenTypeIsVideo()
		{
			// Arrange
			var factory = AcademyFactory.Instance;

			// Act
			var resource = factory.CreateLectureResource("video", "valid name", "http://validurl.com/");

			// Assert
			Assert.IsInstanceOf(typeof(VideoResource), resource);
		}

		[Test]
		public void ReturnPresentationResource_WhenTypeIsPresentation()
		{
			// Arrange
			var factory = AcademyFactory.Instance;

			// Act
			var resource = factory.CreateLectureResource("presentation", "valid name", "http://validurl.com/");

			// Assert
			Assert.IsInstanceOf(typeof(PresentationResource), resource);
		}

		[Test]
		public void ReturnDemoResource_WhenTypeIsDemo()
		{
			// Arrange
			var factory = AcademyFactory.Instance;

			// Act
			var resource = factory.CreateLectureResource("demo", "valid name", "http://validurl.com/");

			// Assert
			Assert.IsInstanceOf(typeof(DemoResource), resource);
		}

		[Test]
		public void ReturnHomeworkResource_WhenTypeIsHomework()
		{
			// Arrange
			var factory = AcademyFactory.Instance;

			// Act
			var resource = factory.CreateLectureResource("homework", "valid name", "http://validurl.com/");

			// Assert
			Assert.IsInstanceOf(typeof(HomeworkResource), resource);
		}
	}
}
