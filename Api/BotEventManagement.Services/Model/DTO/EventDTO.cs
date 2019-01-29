using EventManager.Services.Converters;
using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System;

namespace EventManager.Services.Model.DTO
{
    public class EventDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("descricao")]
        public string Description { get; set; }
        [JsonProperty("dataInicio"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime StartDate { get; set; }
        [JsonProperty("dataTermino"), JsonConverter(typeof(DateFormatConverter), "dd/MM/yyyy HH:mm")]
        public DateTime EndDate { get; set; }
        [JsonProperty("endereco")]
        public Address Address { get; set; }
    }
}
