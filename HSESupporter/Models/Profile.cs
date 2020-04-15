using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Profile
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("fio")] public string Fio { get; set; }
        [JsonProperty("info")] public string Info { get; set; }
        [JsonProperty("role")] public string Role { get; set; }
        [JsonProperty("dormitory")] public string Dormitory { get; set; }
    }
}