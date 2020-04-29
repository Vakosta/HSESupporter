using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Profile
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("first_name")] public string FirstName { get; set; }
        [JsonProperty("last_name")] public string LastName { get; set; }
        [JsonProperty("info")] public string Info { get; set; }
        [JsonProperty("role")] public string Role { get; set; }
        [JsonProperty("dormitory")] public Dormitory Dormitory { get; set; }
    }
}