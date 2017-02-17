using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Tests.Repositories.Fakes;

namespace PackageManager.Tests.Repositories
{
	[TestFixture]
	public class PackageRepositoryTests
	{
		[Test]
		public void Add_ShouldThrowArgumentNullException_WhenPackageIsNull()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var sut = new PackageRepository(loggerStub.Object);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				sut.Add(null)
			);
		}

		[Test]
		public void Add_ShouldAddPackage_WhenPackageDoesNotExist()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var sut = new PackageRepositoryFake(loggerStub.Object);

			var packageMock = new Mock<IPackage>();

			// Act 
			sut.Add(packageMock.Object);

			// Assert
			Assert.IsTrue(sut.Packages.Contains(packageMock.Object));
		}

		[Test]
		public void Add_ShouldLogMessage_WhenPackageDoesNotExistAndWasAdded()
		{
			// Arrange
			var logs = new List<string>();

			var loggerStub = new Mock<ILogger>();
			loggerStub.Setup(x => x.Log(It.IsAny<string>())).Callback((string a) =>
				logs.Add(a)
			);

			var sut = new PackageRepository(loggerStub.Object);

			var packageMock = new Mock<IPackage>();

			// Act 
			sut.Add(packageMock.Object);

			// Assert
			var logsContainCorrectMessage = logs.Any(x => x.Contains("added"));

			Assert.IsTrue(logsContainCorrectMessage);
		}

		[Test]
		public void Add_ShouldLogMessage_WhenPackageWithTheSameVersionExists()
		{
			// Arrange
			var logs = new List<string>();

			var loggerStub = new Mock<ILogger>();
			loggerStub.Setup(x => x.Log(It.IsAny<string>())).Callback((string a) =>
				logs.Add(a)
			);

			var existingPackageMock = new Mock<IPackage>();
			existingPackageMock.Setup(x => x.Name).Returns("name");

			var packages = new HashSet<IPackage>() { existingPackageMock.Object };

			var sut = new PackageRepository(loggerStub.Object, packages);

			var newPackageMock = new Mock<IPackage>();
			newPackageMock.Setup(x => x.Name).Returns("name");
			newPackageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);

			// Act 
			sut.Add(newPackageMock.Object);

			// Assert
			var logsContainCorrectMessage = logs.Any(x => x.Contains("same version"));

			Assert.IsTrue(logsContainCorrectMessage);
		}

		[Test]
		public void Add_ShouldLogMessage_WhenPackageWithHigherVersioExists()
		{
			// Arrange
			var logs = new List<string>();

			var loggerStub = new Mock<ILogger>();
			loggerStub.Setup(x => x.Log(It.IsAny<string>())).Callback((string a) =>
				logs.Add(a)
			);

			var existingPackageStub = new Mock<IPackage>();
			existingPackageStub.Setup(x => x.Name).Returns("name");

			var packages = new HashSet<IPackage>() { existingPackageStub.Object };

			var sut = new PackageRepository(loggerStub.Object, packages);

			var newPackageStub = new Mock<IPackage>();
			newPackageStub.Setup(x => x.Name).Returns("name");
			newPackageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);

			// Act 
			sut.Add(newPackageStub.Object);

			// Assert
			var logsContainCorrectMessage = logs.Any(x => x.Contains("newer version"));

			Assert.IsTrue(logsContainCorrectMessage);
		}

		[Test]
		public void Add_ShouldCallUpdate_WhenPackageWithLowerVersioExists()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var existingPackageStub = new Mock<IPackage>();
			existingPackageStub.Setup(x => x.Name).Returns("name");

			var packages = new HashSet<IPackage>() { existingPackageStub.Object };

			var sut = new PackageRepositoryFake(loggerStub.Object, packages);

			var newPackageStub = new Mock<IPackage>();
			newPackageStub.Setup(x => x.Name).Returns("name");
			newPackageStub.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);

			// Act 
			var testException = Assert.Catch(() => sut.Add(newPackageStub.Object));

			// Assert
			Assert.AreEqual("Update was called", testException.Message);
		}

		[Test]
		public void Delete_ShouldThrowArgumentNullException_WhenPackageIsNull()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var sut = new PackageRepository(loggerStub.Object);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				sut.Delete(null)
			);
		}

		[Test]
		public void Delete_ShouldThrowArgumentNullExceptionAndLogMessage_WhenPackageIsNotFound()
		{
			// Arrange
			var logs = new List<string>();

			var loggerStub = new Mock<ILogger>();
			loggerStub.Setup(x => x.Log(It.IsAny<string>())).Callback((string a) =>
				logs.Add(a)
			);

			var packageStub = new Mock<IPackage>();

			var packages = new HashSet<IPackage>();
			var sut = new PackageRepository(loggerStub.Object, packages);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(
				() => sut.Delete(packageStub.Object)
			);

			var logsContainCorrectMessage = logs.Any(x => x.Contains("not exist"));

			Assert.IsTrue(logsContainCorrectMessage);
		}

		[Test]
		public void Update_ShouldThrowArgumentNullException_WhenPackageIsNull()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var sut = new PackageRepository(loggerStub.Object);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				sut.Update(null)
			);
		}

		[Test]
		public void Update_ShouldThrowArgumentNullExceptionAndLogMessage_WhenPackageIsNotFound()
		{
			// Arrange
			var logs = new List<string>();

			var loggerStub = new Mock<ILogger>();
			loggerStub.Setup(x => x.Log(It.IsAny<string>())).Callback((string a) =>
				logs.Add(a)
			);

			var packageStub = new Mock<IPackage>();

			var packages = new HashSet<IPackage>();
			var sut = new PackageRepository(loggerStub.Object, packages);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(
				() => sut.Update(packageStub.Object)
			);

			var logsContainCorrectMessage = logs.Any(x => x.Contains("not exist"));

			Assert.IsTrue(logsContainCorrectMessage);
		}

		[Test]
		public void GetAll_ShouldReturnEmptyCollection_WhenNoCollectionIsPassed()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();
			var sut = new PackageRepository(loggerStub.Object);

			// Act
			var result = sut.GetAll();

			// Assert
			Assert.IsInstanceOf<IEnumerable<IPackage>>(result);
		}

		[Test]
		public void GetAll_ShouldReturnACollectionWithTheSamAmmountOfElementsAsPassed()
		{
			// Arrange
			var loggerStub = new Mock<ILogger>();

			var packageStub1 = new Mock<IPackage>();
			var packageStub2 = new Mock<IPackage>();

			var packages = new HashSet<IPackage>()
			{
				packageStub1.Object,
				packageStub2.Object,
			};

			var sut = new PackageRepository(loggerStub.Object, packages);

			// Act
			var result = sut.GetAll();

			// Assert
			Assert.AreEqual(2, result.Count());
		}
	}
}
