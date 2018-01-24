using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tcb_documentdb
{
    public class Blog
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("comments")]
        public List<Comment> Comments { get; set; }
    }



    public class Comment
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("authorName")]
        public string AuthorName { get; set; }

        [JsonProperty("_ts")]
        public string TimeStamp { get; set; }
    }
}
