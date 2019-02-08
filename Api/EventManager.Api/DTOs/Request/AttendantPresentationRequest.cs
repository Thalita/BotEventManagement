using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Request
{
    public class AttendantPresentationRequest
    {
        [JsonProperty("attendantId")]
        public int AttendantId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
