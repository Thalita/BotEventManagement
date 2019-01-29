using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO
{
    public class AttendantPresentationDTO
    {
        [JsonProperty("idUsuario")]
        public int UserId { get; set; }
        [JsonProperty("idApresentacao")]
        public int PresentationId { get; set; }
    }
}
