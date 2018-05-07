using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bitbucket.Cloud.Net.v1.Repositories.Models
{
    public class BranchObject
    {
        public string Node { get; set; }
        public List<FileObject> Files { get; set; }
        [JsonProperty("raw_author")]
        public string RawAuthor { get; set; }
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UtcTimestamp { get; set; }
        public string Author { get; set; }
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Timestamp { get; set; }
        [JsonProperty("raw_node")]
        public string RawNode { get; set; }
        public List<string> Parents { get; set; }
        public string Branch { get; set; }
        public string Message { get; set; }
        public object Revision { get; set; }
        public int Size { get; set; }
    }
}
