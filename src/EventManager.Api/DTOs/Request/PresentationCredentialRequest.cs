using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Request
{
    public class PresentationCredentialRequest
    {
        [JsonProperty("presentationId")]
        public int PresentationId { get; set; }

        [JsonProperty("credentialId")]
        public int CredentialId { get; set; }  
    }
}
