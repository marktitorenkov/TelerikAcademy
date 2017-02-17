using System;
using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Fakes;

namespace PackageManager.Tests.Commands
{
	[TestFixture]
	public class InstallCommandTests
	{
		[Test]
		public void ConstructorShould_CorrectlyAssignPassedInstaller()
		{
			// Arrange & Act
			var installerMock = new Mock<IInstaller<IPackage>>();
			var packageStub = new Mock<IPackage>();

			var sut = new InstallCommandFake(installerMock.Object, packageStub.Object);

			// Assert
			Assert.AreSame(installerMock.Object, sut.Installer);
		}

		[Test]
		public void ConstructorShould_ThrowArgumentNullException_WhenPassedInstallerIsNull()
		{
			// Arrange
			var packageStub = new Mock<IPackage>();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() => 
				new InstallCommandFake(null, packageStub.Object)
			);
		}

		[Test]
		public void ConstructorShould_CorrectlyAssignPassedPackage()
		{
			// Arrange & Act
			var installerStub = new Mock<IInstaller<IPackage>>();
			var packageMock = new Mock<IPackage>();

			var sut = new InstallCommandFake(installerStub.Object, packageMock.Object);

			// Assert
			Assert.AreSame(packageMock.Object, sut.Package);
		}

		[Test]
		public void ConstructorShould_ThrowArgumentNullException_WhenPassedPackageIsNull()
		{
			// Arrange
			var installerStub = new Mock<IInstaller<IPackage>>();

			// Act & Assert
			Assert.Throws<ArgumentNullException>(() =>
				new InstallCommandFake(installerStub.Object, null)
			);
		}

		[Test]
		public void ConstructorShould_CorrectlySetInstallerOperation()
		{
			// Arrange & Act
			var installerMock = new Mock<IInstaller<IPackage>>();
			var packageStub = new Mock<IPackage>();

			var sut = new InstallCommandFake(installerMock.Object, packageStub.Object);

			// Assert
			Assert.AreEqual(InstallerOperation.Install, sut.Installer.Operation);
		}

		[Test]
		public void ExecuteShould_CallPerformOperationOfInstaller()
		{
			// Arrange
			var installerMock = new Mock<IInstaller<IPackage>>();
			installerMock.Setup(x => x.PerformOperation(It.IsAny<IPackage>()));
			var packageStub = new Mock<IPackage>();

			var sut = new InstallCommandFake(installerMock.Object, packageStub.Object);

			// Act
			sut.Execute();

			// Assert
			installerMock.Verify(x => x.PerformOperation(packageStub.Object), Times.Once);
		}
	}
}
