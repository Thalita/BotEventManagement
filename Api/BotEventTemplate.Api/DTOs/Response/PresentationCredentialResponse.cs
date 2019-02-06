using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Response
{
    public class PresentationCredentialResponse
    {
        [JsonProperty("presentation")]
        public PresentationResponse Presentation { get; set; }

        [JsonProperty("credential")]
        public CredentialResponse CredentialResponse { get; set; }  
    }
}
