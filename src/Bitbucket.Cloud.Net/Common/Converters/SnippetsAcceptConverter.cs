using Bitbucket.Cloud.Net.Models;

namespace Bitbucket.Cloud.Net.Common.Converters
{
	public static class SnippetsAcceptConverter
	{
		public static string ConvertToString(SnippetsAccept value)
		{
			return value switch
			{
				SnippetsAccept.MultiPartRelated => "multipart/related",
				SnippetsAccept.MultiPartFormData => "multipart/formdata",
				_ => "application/json"
			};
		}
	}
}
