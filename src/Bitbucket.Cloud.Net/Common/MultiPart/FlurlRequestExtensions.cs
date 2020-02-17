using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
// ReSharper disable RedundantTypeSpecificationInDefaultExpression

namespace Bitbucket.Cloud.Net.Common.MultiPart
{
	public static class FlurlRequestExtensions
	{
		public static Task<IEnumerable<ContentPart>> GetMultiPartRelatedAsync(this IFlurlRequest request, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			return request.SendAsync(HttpMethod.Get, cancellationToken: cancellationToken, completionOption: completionOption).ReceiveMultiPartRelatedAsync();
		}

		public static Task<IEnumerable<ContentPart>> GetMultiPartFormDataAsync(this IFlurlRequest request, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			return request.SendAsync(HttpMethod.Get, cancellationToken: cancellationToken, completionOption: completionOption).ReceiveMultiPartFormDataAsync();
		}
	}
}
