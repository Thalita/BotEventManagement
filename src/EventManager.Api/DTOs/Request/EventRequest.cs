using EventManager.Services.Converters;
using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System;

namespace EventManager.Api.DTOs.Request
{
    public class EventRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("startDate"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
