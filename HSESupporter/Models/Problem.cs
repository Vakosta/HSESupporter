using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Problem : IModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("author")] public string Author { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("has_new_messages")] public bool HasNewMessages { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }
        [JsonProperty("messages")] public List<Message> Messages { get; set; }

        public string CreatedAtBeauty
        {
            get
            {
                var dateTime = DateTime.Parse(CreatedAt);
                return dateTime.ToString("dd MMMM HH:mm");
            }
        }

        public Dictionary<string, object> GetDictionaryParams()
        {
            return new Dictionary<string, object>
            {
                {"id", Id},
                {"name", Author},
                {"title", Title},
                {"description", Description},
                {"status", Status},
                {"created_at", CreatedAt},
                {"updated_at", UpdatedAt},
                {"message", Messages}
            };
        }
    }
}