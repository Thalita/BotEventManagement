using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Response
{
    public class SpeakerPresentationResponse
    {
        [JsonProperty("speakerId")]
        public int SpeakerId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
