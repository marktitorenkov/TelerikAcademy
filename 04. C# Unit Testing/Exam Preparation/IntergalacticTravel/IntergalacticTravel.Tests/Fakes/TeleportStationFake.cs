using System.Collections.Generic;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.Fakes
{
	internal class TeleportStationFake: TeleportStation
	{
		internal TeleportStationFake(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location)
			: base(owner, galacticMap, location)
		{
		}

		internal IResources Resources
		{
			get { return this.resources; }
		}
		internal IBusinessOwner Owner
		{
			get { return this.owner; }
		}
		internal ILocation Location
		{
			get { return this.location; }
		}
		internal IEnumerable<IPath> GalacticMap
		{
			get { return this.galacticMap; }
		}
	}
}
