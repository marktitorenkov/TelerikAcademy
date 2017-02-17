using System;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;

namespace PackageManager.Tests.Models
{
	[TestFixture]
	public class PackageVersionTests
	{
		[Test]
		public void Constructor_ShouldCorrectlySetMajor_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var sut = new PackageVersion(0, 0, 0, VersionType.alpha);

			// Assert
			Assert.AreEqual(0, sut.Major);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetMinor_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var sut = new PackageVersion(0, 0, 0, VersionType.alpha);

			// Assert
			Assert.AreEqual(0, sut.Minor);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetPatch_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var sut = new PackageVersion(0, 0, 0, VersionType.alpha);

			// Assert
			Assert.AreEqual(0, sut.Patch);
		}

		[Test]
		public void Constructor_ShouldCorrectlySetVersionType_WhenPassedValueIsValid()
		{
			// Arrange & Act
			var sut = new PackageVersion(0, 0, 0, VersionType.alpha);

			// Assert
			Assert.AreEqual(VersionType.alpha, sut.VersionType);
		}

		[Test]
		public void Major_ShouldThrowArgumentExeption_WhenValueIsInvalid()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(
				() => new PackageVersion(-1, 0, 0, VersionType.alpha)
			);
		}

		[Test]
		public void Minor_ShouldThrowArgumentExeption_WhenValueIsInvalid()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(
				() => new PackageVersion(0, -1, 0, VersionType.alpha)
			);
		}

		[Test]
		public void Patch_ShouldThrowArgumentExeption_WhenValueIsInvalid()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(
				() => new PackageVersion(0, 0, -1, VersionType.alpha)
			);
		}

		[Test]
		public void VersionType_ShouldThrowArgumentExeption_WhenValueIsInvalid()
		{
			// Act & Assert
			Assert.Throws<ArgumentException>(
				() => new PackageVersion(0, 0, 0, (VersionType)20)
			);
		}
	}
}
