using Academy.Models.Abstractions;

namespace Academy.Tests.Models.Abstractions
{
	public class UserFake: User
	{
		public UserFake(string username) : base(username)
		{
		}
	}
}