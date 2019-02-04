using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Response
{
    public class SponsorResponse
    {
        [JsonProperty("id")]
        public int SponsorId { get; set; }

        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pageUrl")]
        public string PageURL { get; set; }

        [JsonProperty("uploadedPhoto")]
        public string UploadedPhoto { get; set; }
    }
}
