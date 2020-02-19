using System;
using System.Text;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public class CustomEncodingProvider : EncodingProvider
	{
		public static CustomEncodingProvider Instance => new CustomEncodingProvider();

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

			if (name.Equals("\"us-ascii\"", StringComparison.OrdinalIgnoreCase))
			{
				return Encoding.ASCII;
			}

			return Encoding.Unicode;
		}
	}
}
