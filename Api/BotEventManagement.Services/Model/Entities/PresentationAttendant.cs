using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class PresentationAttendant
    {
        [ForeignKey("PresentationId")]
        public int PresentationId { get; set; }
        public virtual Presentation Presentation { get; set; }

        [ForeignKey("AttendantId")]
        public int AttendantId { get; set; }
        public virtual Attendant Attendant { get; set; }
    }
}
