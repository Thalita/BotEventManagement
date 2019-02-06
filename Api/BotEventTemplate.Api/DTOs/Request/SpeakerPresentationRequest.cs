using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Request
{
    public class SpeakerPresentationRequest
    {
        [JsonProperty("speakerId")]
        public int SpeakerId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
