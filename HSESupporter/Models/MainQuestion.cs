using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class MainQuestion
    {
        [JsonProperty("question")] public string Question { get; set; }
        [JsonProperty("answer")] public string Answer { get; set; }
    }
}