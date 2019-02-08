using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Services.Model.Entities
{
    public class Speaker
    {
        [Key]
        public int SpeakerId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public string UploadedPhoto { get; set; }

        public virtual IList<SpeakerPresentation> SpeakerPresentations { get; set; }
    }
}
