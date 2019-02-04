using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Request
{
    public class AttendantPresentationRequest
    {
        [JsonProperty("attendantId")]
        public int AttendantId { get; set; }

        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }
    }
}
