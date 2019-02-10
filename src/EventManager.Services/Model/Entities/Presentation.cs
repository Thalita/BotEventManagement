using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class Presentation
    {
        [Key]
        public int PresentationId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public string Category { get; set; }
        public string Local { get; set; }

        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual IList<PresentationAttendant> PresentationAttendants { get; set; }
        public virtual IList<PresentationCredential> PresentationCredentials { get; set; }
        public virtual IList<SpeakerPresentation> SpeakerPresentations { get; set; }

    }
}
