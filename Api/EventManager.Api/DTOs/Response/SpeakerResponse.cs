using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Api.DTOs.Response
{
    public class SpeakerResponse
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
        public IList<PresentationResponse> Presentations;
    }
}
