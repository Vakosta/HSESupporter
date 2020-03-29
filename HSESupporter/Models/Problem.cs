using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Problem : IModel
    {
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

        public Dictionary<string, string> GetDictionaryParams()
        {
            return new Dictionary<string, string>
            {
                {"name", Author},
                {"title", Title},
                {"description", Description},
                {"status", Status},
                {"created_at", CreatedAt},
                {"updated_at", UpdatedAt}
            };
        }
    }
}