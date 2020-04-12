using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Profile
    {
        [JsonProperty("token")] public string Fio { get; set; }
        [JsonProperty("fio")] public string Info { get; set; }
        [JsonProperty("dormitory")] public string Dormitory { get; set; }
    }
}