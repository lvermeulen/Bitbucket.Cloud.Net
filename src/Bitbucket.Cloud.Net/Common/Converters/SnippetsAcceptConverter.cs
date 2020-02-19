using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public static class SnippetsAcceptConverter
	{
		public static string ConvertToString(SnippetsAccept value)
		{
			return value switch
			{
				SnippetsAccept.MultipartRelated => "multipart/related",
				SnippetsAccept.MultipartFormdata => "multipart/formdata",
				_ => "application/json"
			};
		}
	}
}
