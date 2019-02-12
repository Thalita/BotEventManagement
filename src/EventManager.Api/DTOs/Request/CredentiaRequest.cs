using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Request
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
