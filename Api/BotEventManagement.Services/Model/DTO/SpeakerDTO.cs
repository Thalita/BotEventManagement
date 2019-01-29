using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO
{
    public class SpeakerDTO
    {
        [JsonProperty("id")]
        public int SpeakerId { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }
        [JsonProperty("biografia")]
        public string Biography { get; set; }
        [JsonProperty("foto")]
        public string UploadedPhoto { get; set; }
    }
}
