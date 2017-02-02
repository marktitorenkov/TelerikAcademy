namespace StringBuilderSubstring
{
	using System.Text;

	public static class StringBuilderExtensions
	{
		public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
		{
			string substr = sb.ToString().Substring(startIndex, length);
			return new StringBuilder(substr);
		}
		public static StringBuilder Substring(this StringBuilder sb, int startIndex)
		{
			string substr = sb.ToString().Substring(startIndex);
			return new StringBuilder(substr);
		}
	}
}