using System;
using System.Collections.Generic;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;

namespace PackageManager.Tests.Repositories.Fakes
{
	internal class PackageRepositoryFake: PackageRepository
	{
		public PackageRepositoryFake(ILogger logger, ICollection<IPackage> packages = null)
			: base(logger, packages)
		{
		}

		internal ICollection<IPackage> Packages
		{
			get
			{
				return base.packages;
			}
		}

		public override bool Update(IPackage package)
		{
			throw new Exception("Update was called");
		}
	}
}
