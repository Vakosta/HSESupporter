using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Message : IModel
    {
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("is_read")] public string IsRead { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

        public Dictionary<string, string> GetDictionaryParams()
        {
            return new Dictionary<string, string>
            {
                {"name", Author},
                {"text", Text},
                {"is_read", IsRead},
                {"created_at", CreatedAt},
                {"updated_at", UpdatedAt}
            };
        }
    }
}