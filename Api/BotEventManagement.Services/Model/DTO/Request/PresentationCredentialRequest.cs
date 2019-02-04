using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Request
{
    public class PresentationCredentialRequest
    {
        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }

        [JsonProperty("credentialId")]
        public int CredentialId { get; set; }  
    }
}
