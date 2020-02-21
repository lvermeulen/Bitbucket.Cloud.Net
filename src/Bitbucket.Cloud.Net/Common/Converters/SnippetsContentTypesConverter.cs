using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public static class SnippetsContentTypesConverter
	{
		public static string ConvertToString(SnippetsContentTypes value)
		{
			return value switch
			{
				SnippetsContentTypes.MultipartRelated => "multipart/related",
				SnippetsContentTypes.MultipartFormdata => "multipart/formdata",
				_ => "application/json"
			};
		}
	}
}
