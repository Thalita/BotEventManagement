using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class Speaker
    {
        [Key]
        public int SpeakerId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Biography { get; set; }
        public string UploadedPhoto { get; set; }


        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual IList<SpeakerPresentation> SpeakerPresentations { get; set; }
    }
}
