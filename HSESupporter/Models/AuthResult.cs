using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class AuthResult
    {
        [JsonProperty("auth_token")] public string Token { get; set; }
    }
}