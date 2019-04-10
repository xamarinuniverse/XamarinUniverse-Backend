using Newtonsoft.Json;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XamarinUniverse_Backend.Models
{
    public class GithubResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("sha")]
        public string Sha { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }

        public byte[] ByteArray => Convert.FromBase64CharArray(Content.ToCharArray(), 0, Content.Length);
        public string StringValue => System.Text.Encoding.UTF8.GetString(ByteArray);
        public bool IsMd => Name.Split(".").LastOrDefault().ToLower() == "md";
    }
}
