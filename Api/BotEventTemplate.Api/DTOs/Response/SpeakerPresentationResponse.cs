using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Response
{
    public class SpeakerPresentationResponse
    {
        [JsonProperty("speakerId")]
        public int SpeakerId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
