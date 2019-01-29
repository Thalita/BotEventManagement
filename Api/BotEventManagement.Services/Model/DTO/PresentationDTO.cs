using EventManager.Services.Converters;
using Newtonsoft.Json;
using System;

namespace EventManager.Services.Model.DTO
{
    public class PresentationDTO
    {
        [JsonProperty("id")]
        public int PresentationId { get; set; }
        [JsonProperty("data"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime Date { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("idEvento")]
        public int EventId { get; set; }
    }
}
