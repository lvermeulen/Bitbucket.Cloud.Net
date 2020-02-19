using System;
using System.Text;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public class MultipartEncodingProvider : EncodingProvider
	{
		public static MultipartEncodingProvider Instance => new MultipartEncodingProvider();

		public override Encoding GetEncoding(int codepage)
		{
			return Encoding.Unicode;
		}

		public override Encoding GetEncoding(string name)
		{
			if (name.Equals("\"utf-8\"", StringComparison.OrdinalIgnoreCase))
			{
				return Encoding.UTF8;
			}

			return name.Equals("\"us-ascii\"", StringComparison.OrdinalIgnoreCase) ? Encoding.ASCII : Encoding.Unicode;
		}
	}
}
