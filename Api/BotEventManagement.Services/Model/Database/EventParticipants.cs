﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BotEventManagement.Services.Model.Database
{
    [Table("EventParticipants")]
    public class EventParticipants
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nome")]
        public string Name { get; set; }

        [ForeignKey("EventId"), JsonProperty("idEvento")]
        public string EventId { get; set; }
        [JsonIgnore]
        public virtual Event Event { get; set; }
    }
}
