using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Request
{
    public class SpeakerPresentationRequest
    {
        [JsonProperty("speakerId")]
        public int SpeakerId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
