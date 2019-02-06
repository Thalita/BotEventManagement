using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Api.DTOs.Request
{
    public class SpeakerRequest
    {
        [JsonProperty("id")]
        public int SpeakerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("photo")]
        public string UploadedPhoto { get; set; }

        [JsonProperty("presentations")]
        public IList<PresentationRequest> Presentations;
    }
}
