﻿using Newtonsoft.Json;

namespace EventManager.Api.DTOs.Response
{
    public class SponsorResponse
    {
        [JsonProperty("id")]
        public int SponsorId { get; set; }

        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pageUrl")]
        public string PageURL { get; set; }

        [JsonProperty("uploadedPhoto")]
        public string UploadedPhoto { get; set; }
    }
}
