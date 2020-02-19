using System.Text;
using Newtonsoft.Json;

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public class MultipartContentSection
	{
		public string ContentType { get; }
		public string TransferEncoding { get; }
		public string ContentDispositionName { get; }
		public string ContentDispositionFileName { get; }
		public string Contents { get; }

		public T AsJson<T>(JsonSerializerSettings settings = null) => settings == null ? JsonConvert.DeserializeObject<T>(Contents) : JsonConvert.DeserializeObject<T>(Contents, settings);
		public string AsText() => Contents;
		public byte[] AsBytes() => Encoding.UTF8.GetBytes(Contents);

		public MultipartContentSection(string contentType, string transferEncoding, string contentDispositionName, string contentDispositionFileName, string contents)
		{
			ContentType = contentType;
			TransferEncoding = transferEncoding;
			ContentDispositionName = contentDispositionName;
			ContentDispositionFileName = contentDispositionFileName;
			Contents = contents;
		}
	}
}
