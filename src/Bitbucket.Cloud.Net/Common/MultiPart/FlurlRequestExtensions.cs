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
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0034:Simplify 'default' expression", Justification = "<Pending>")]
		public static Task<IEnumerable<MultipartContentSection>> GetMultipartAsync(this IFlurlRequest request, CancellationToken cancellationToken = default(CancellationToken), HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
		{
			return request.SendAsync(HttpMethod.Get, cancellationToken: cancellationToken, completionOption: completionOption).ReceiveMultipartAsync();
		}
	}
}
