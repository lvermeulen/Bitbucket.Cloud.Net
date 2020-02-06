using System.Collections.Generic;

namespace Bitbucket.Cloud.Net.Common.Models
{
    public class PagedResults<T>
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public int PageLen { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<T> Values { get; set; }
    }
}
