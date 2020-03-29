using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Dormitory : IModel
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("address")] public string Address { get; set; }

        public Dictionary<string, string> GetDictionaryParams()
        {
            return new Dictionary<string, string>
            {
                {"name", Name},
                {"address", Address}
            };
        }
    }
}