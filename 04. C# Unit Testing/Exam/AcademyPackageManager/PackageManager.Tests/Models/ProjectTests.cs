using System;
using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models
{
	[TestFixture]
	public class ProjectTests
	{
		[Test]
		public void Constructor_ShouldCorrectlySetName_WhenPassedValueIsValid()
		{
			// Act & Arrange
			var sut = new Project("name", "location");

			// Assert
			Assert.AreEqual("name", sut.Name);
        }

		[Test]
		public void Constructor_ShouldThrowArgumentNullException_WhenPassedNameIsNull()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new Project(null, "location")
			);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetLocation_WhenPassedValueIsValid()
		{
			// Act & Arrange
			var sut = new Project("name", "location");

			// Assert
			Assert.AreEqual("location", sut.Location);
		}

		[Test]
		public void Constructor_ShouldThrowArgumentNullException_WhenPassedLocationIsNull()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new Project("name", null)
			);
		}

		[Test]
		public void Constructor_ShouldCorrectlySePackageRepository_WhenParameterIsOptional()
		{
			// Act & Arrange
			var sut = new Project("name", "location");

			// Assert
			Assert.IsInstanceOf<PackageRepository>(sut.PackageRepository);
		}

		[Test]
		public void Constructor_ShouldCorrectlySePackageRepository_WhenParameterIsPassed()
		{
			// Act & Arrange
			var packageRepositoryStub = new Mock<IRepository<IPackage>>();
            var sut = new Project("name", "location", packageRepositoryStub.Object);

			// Assert
			Assert.AreSame(packageRepositoryStub.Object, sut.PackageRepository);
		}
	}
}
