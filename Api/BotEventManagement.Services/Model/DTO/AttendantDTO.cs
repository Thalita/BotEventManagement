using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Services.Model.DTO
{
    public class AttendantDTO
    {
        [JsonProperty("attendantId")]
        public int AttendantId { get; set; }
        [JsonProperty("idEvento")]
        public int EventId { get; set; }
        [JsonProperty("idCredencial")]
        public int CredentialId { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("apresentacoes")]
        public IList<Presentation> Presentations;
    }
}
