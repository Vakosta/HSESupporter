using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class AuthResult
    {
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("profile")] public Profile Profile { get; set; }
    }
}