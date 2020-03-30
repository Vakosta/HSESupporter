using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Dormitory : IModel
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("address")] public string Address { get; set; }

        public Dictionary<string, object> GetDictionaryParams()
        {
            return new Dictionary<string, object>
            {
                {"id", Id},
                {"name", Name},
                {"address", Address}
            };
        }
    }
}