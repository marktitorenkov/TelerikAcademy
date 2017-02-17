using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models
{
	[TestFixture]
	public class PackageTest
	{
		[Test]
		public void Constructor_ShouldCorrectlySetName_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var versionStub = new Mock<IVersion>();
			var sut = new Package("name", versionStub.Object);

			// Assert
			Assert.AreEqual("name", sut.Name);
		}

		[Test]
		public void Constructor_ShouldThrowArgumentNullException_WhenPassedNameIsNull()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new Package(null, versionStub.Object)
			);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetVersion_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var versionMock = new Mock<IVersion>();
			var sut = new Package("name", versionMock.Object);

			// Assert
			Assert.AreSame(versionMock.Object, sut.Version);
		}

		[Test]
		public void Constructor_ShouldThrowArgumentNullException_WhenPassedVersionIsNull()
		{
			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new Package("name", null)
			);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetUrl_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.beta);
			var sut = new Package("name", versionStub.Object);

			// Assert
			Assert.AreEqual("1.2.3-beta", sut.Url);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetDependencies_WhenValueIsOptional()
		{
			// Arrange & Act
			var versionStub = new Mock<IVersion>();
			var sut = new Package("name", versionStub.Object);

			// Assert
			Assert.IsInstanceOf<HashSet<IPackage>>(sut.Dependencies);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetDependencies_WhenValueIsPassed()
		{
			// Arrange & Act
			var versionStub = new Mock<IVersion>();
			var dependeciesMock = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesMock.Object);

			// Assert
			Assert.AreSame(dependeciesMock.Object, sut.Dependencies);
		}

		[Test]
		public void CompareTo_ShouldThrowArgumentNullException_WhenOtherIsNull()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				sut.CompareTo(null)
			);
		}

		[Test]
		public void CompareTo_ShouldThrowArgumentException_WhenOtherIsNotWithTheSameName()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("othername");

			// Act & Assert
			Assert.Throws<ArgumentException>(() =>
				sut.CompareTo(otherPackageMock.Object)
			);
		}

		[Test]
		public void CompareTo_ShouldReturnMinusOne_WhenOtherHasAHigherVersion()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherVersionStub = new Mock<IVersion>();
			otherVersionStub.Setup(x => x.Major).Returns(2);
			otherVersionStub.Setup(x => x.Minor).Returns(3);
			otherVersionStub.Setup(x => x.Patch).Returns(4);
			otherVersionStub.Setup(x => x.VersionType).Returns(VersionType.beta);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("name");
			otherPackageMock.Setup(x => x.Version).Returns(otherVersionStub.Object);

			// Act
			var result = sut.CompareTo(otherPackageMock.Object);

			// Assert
			Assert.AreEqual(-1, result);
		}

		[Test]
		public void CompareTo_ShouldReturnOne_WhenOtherHasALowerVersion()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherVersionStub = new Mock<IVersion>();
			otherVersionStub.Setup(x => x.Major).Returns(0);
			otherVersionStub.Setup(x => x.Minor).Returns(1);
			otherVersionStub.Setup(x => x.Patch).Returns(2);
			otherVersionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("name");
			otherPackageMock.Setup(x => x.Version).Returns(otherVersionStub.Object);

			// Act
			var result = sut.CompareTo(otherPackageMock.Object);

			// Assert
			Assert.AreEqual(1, result);
		}

		[Test]
		public void CompareTo_ShouldReturnZero_WhenOtherHasATheSameVersion()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherVersionStub = new Mock<IVersion>();
			otherVersionStub.Setup(x => x.Major).Returns(1);
			otherVersionStub.Setup(x => x.Minor).Returns(2);
			otherVersionStub.Setup(x => x.Patch).Returns(3);
			otherVersionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("name");
			otherPackageMock.Setup(x => x.Version).Returns(otherVersionStub.Object);

			// Act
			var result = sut.CompareTo(otherPackageMock.Object);

			// Assert
			Assert.AreEqual(0, result);
		}

		[Test]
		public void Equals_ShouldThrowArgumentNullException_WhenOtherIsNull()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				sut.Equals(null)
			);
		}

		[Test]
		public void Equals_ShouldThrowArgumentException_WhenOtherIsNotIPAckage()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			object other = new DateTime();

			// Act & Assert
			Assert.Throws<ArgumentException>(() =>
				sut.Equals(other)
			);
		}

		[Test]
		public void Equals_ShouldReturnTrue_WhenPackagesAreEqual()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherVersionStub = new Mock<IVersion>();
			otherVersionStub.Setup(x => x.Major).Returns(1);
			otherVersionStub.Setup(x => x.Minor).Returns(2);
			otherVersionStub.Setup(x => x.Patch).Returns(3);
			otherVersionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("name");
			otherPackageMock.Setup(x => x.Version).Returns(otherVersionStub.Object);

			// Act & Assert
			Assert.IsTrue(sut.Equals(otherPackageMock.Object));
		}

		[Test]
		public void Equals_ShouldReturnFalse_WhenPackagesAreNotEqual()
		{
			// Arrange
			var versionStub = new Mock<IVersion>();
			versionStub.Setup(x => x.Major).Returns(1);
			versionStub.Setup(x => x.Minor).Returns(2);
			versionStub.Setup(x => x.Patch).Returns(3);
			versionStub.Setup(x => x.VersionType).Returns(VersionType.alpha);

			var dependeciesStub = new Mock<ICollection<IPackage>>();
			var sut = new Package("name", versionStub.Object, dependeciesStub.Object);

			var otherVersionStub = new Mock<IVersion>();
			otherVersionStub.Setup(x => x.Major).Returns(10);
			otherVersionStub.Setup(x => x.Minor).Returns(20);
			otherVersionStub.Setup(x => x.Patch).Returns(30);
			otherVersionStub.Setup(x => x.VersionType).Returns(VersionType.beta);

			var otherPackageMock = new Mock<IPackage>();
			otherPackageMock.Setup(x => x.Name).Returns("othername");
			otherPackageMock.Setup(x => x.Version).Returns(otherVersionStub.Object);

			// Act & Assert
			Assert.IsFalse(sut.Equals(otherPackageMock.Object));
		}
	}
}
