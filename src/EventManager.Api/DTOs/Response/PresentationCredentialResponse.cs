using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Api.DTOs.Response
{
    public class PresentationCredentialResponse
    {        
        [JsonProperty("credential")]
        public CredentialResponse Credential { get; set; }

        [JsonProperty("presentations")]
        public IList<PresentationResponse> Presentations;
    }
}
