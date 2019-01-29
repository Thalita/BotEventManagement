using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class SpeakerPresentation
    {
        [ForeignKey("SpeakerId")]
        public int SpeakerId { get; set; }
        public virtual Speaker Speaker { get; set; }

        [ForeignKey("PresentationId")]
        public int PresentationId { get; set; }
        public virtual Presentation Presentation { get; set; }
    }
}
