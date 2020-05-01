using System;
using Newtonsoft.Json;

namespace HSESupporter.Models
{
    public class Event
    {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("title")] public string Title { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("target_date")] public string TargetDate { get; set; }
        [JsonProperty("created_at")] public string CreatedAt { get; set; }
        [JsonProperty("updated_at")] public string UpdatedAt { get; set; }

        /// <summary>
        /// Дата проведения в формате читабельной строки.
        /// </summary>
        public string TargetDateBeauty
        {
            get
            {
                var dateTime = DateTime.Parse(CreatedAt);
                return dateTime.ToString("dd.MM.yyyy HH:mm");
            }
        }

        /// <summary>
        /// Дата создания в формате читабельной строки.
        /// </summary>
        public string CreatedAtBeauty
        {
            get
            {
                var dateTime = DateTime.Parse(CreatedAt);
                return dateTime.ToString("dd.MM.yyyy HH:mm");
            }
        }
    }
}