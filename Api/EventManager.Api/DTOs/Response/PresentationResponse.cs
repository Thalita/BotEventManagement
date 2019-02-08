using EventManager.Services.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EventManager.Api.DTOs.Response
{
    public class PresentationResponse
    {
        [JsonProperty("id")]
        public int PresentationId { get; set; }

        [JsonProperty("date"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime Date { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("theme")]
        public string Theme { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("local")]
        public string Local { get; set; }
    }
}
