using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Message : IModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("author")] public int Author { get; set; }
        [JsonProperty("author_first_name")] public string AuthorFirstName { get; set; }
        [JsonProperty("author_last_name")] public string AuthorLastName { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("is_read")] public bool IsRead { get; set; }
        [JsonProperty("is_from_student")] public bool IsFromStudent { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }
        [JsonProperty("problem")] public int? Problem { get; set; }
        [JsonProperty("dormitory")] public int? Dormitory { get; set; }

        public Dictionary<string, object> GetDictionaryParams()
        {
            var values = new Dictionary<string, object>
            {
                {"id", Id},
                {"name", Author},
                {"text", Text},
                {"is_read", IsRead},
                {"is_from_student", IsFromStudent},
                {"created_at", CreatedAt},
                {"updated_at", UpdatedAt}
            };

            if (Problem != 0) values.Add("problem", Problem);
            if (Dormitory != 0) values.Add("dormitory", Dormitory);

            return values;
        }
    }
}