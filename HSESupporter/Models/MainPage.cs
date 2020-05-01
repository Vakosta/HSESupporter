using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class MainPage
    {
        [JsonProperty("profile")] public Profile Profile { get; set; }
        [JsonProperty("notices")] public List<Notice> Notices { get; set; }
        [JsonProperty("events")] public List<Event> Events { get; set; }
        [JsonProperty("main_questions")] public List<MainQuestion> MainQuestions { get; set; }
    }
}