﻿using EventManager.Services.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EventManager.Services.Model.DTO.Response
{
    public class AttendantResponse
    {
        [JsonProperty("id")]
        public int AttendantId { get; set; }

        [JsonProperty("eventId")]
        public int EventId { get; set; }

        [JsonProperty("credentialId")]
        public int CredentialId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("presentations")]
        public IList<PresentationResponse> Presentations;
    }
}
