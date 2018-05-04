using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Common.Models
{
    public class ErrorResponse
    {
        public IEnumerable<Error> Errors { get; set; }
    }
}
