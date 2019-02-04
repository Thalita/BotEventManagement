using Newtonsoft.Json;

namespace EventManager.Services.Model.DTO.Response
{
    public class PresentationCredentialResponse
    {
        [JsonProperty("presentation")]
        public PresentationResponse Presentation { get; set; }

        [JsonProperty("credential")]
        public CredentialResponse CredentialResponse { get; set; }  
    }
}
