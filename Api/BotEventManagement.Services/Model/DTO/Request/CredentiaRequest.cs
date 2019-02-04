using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Services.Model.DTO.Request
{
    public class CredentiaRequest
    {
        [JsonProperty("id")]
        public int CredentialId { get; set; }

        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
