# thecoreblog-documentdb

This project is an ASP.NET Core 2.0 API to store & manage (CRUD operations) Blog items of the following structure on an Azure DocumentDB (NoSQL).


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
    }
