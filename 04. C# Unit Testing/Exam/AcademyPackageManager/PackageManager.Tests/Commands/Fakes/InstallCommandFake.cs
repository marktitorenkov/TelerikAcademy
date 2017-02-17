using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.Fakes
{
	internal class InstallCommandFake: InstallCommand
	{
		public InstallCommandFake(IInstaller<IPackage> installer, IPackage package)
			: base(installer, package)
		{
		}

		internal IInstaller<IPackage> Installer
		{
			get
			{
				return base.installer;
			}
		}
		internal IPackage Package
		{
			get
			{
				return base.package;
			}
		}
	}
}
