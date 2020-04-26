using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Notice : IModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("main_text")] public string Title { get; set; }
        [JsonProperty("text")] public string Description { get; set; }
        [JsonProperty("is_important")] public bool IsImportant { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

        public string CreatedAtBeauty
        {
            get
            {
                var dateTime = DateTime.Parse(CreatedAt);
                return dateTime.ToString("dd.MM.yyyy HH:mm");
            }
        }

        public Dictionary<string, object> GetDictionaryParams()
        {
            return new Dictionary<string, object>
            {
                {"id", Id},
                {"title", Title},
                {"description", Description},
                {"is_important", IsImportant},
                {"created_at", CreatedAt},
                {"updated_at", UpdatedAt}
            };
        }
    }
}