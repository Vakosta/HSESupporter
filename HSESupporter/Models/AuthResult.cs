using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class AuthResult
    {
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("is_accept")] public bool IsAccept { get; set; }
        [JsonProperty("profile")] public Profile Profile { get; set; }
    }
}