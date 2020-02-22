using Bitbucket.Cloud.Net.Models.v2;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public static class RolesConverter
	{
		public static string ConvertToString(Roles value)
		{
			return value.ToString().ToLowerInvariant();
		}

		public static string ConvertToString(Roles? value)
		{
			return value.HasValue
				? ConvertToString(value.Value)
				: null;
		}
	}
}
