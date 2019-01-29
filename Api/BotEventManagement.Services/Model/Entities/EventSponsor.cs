using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class EventSponsor
    {

        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey("SponsorId")]
        public int SponsorId { get; set; }
        public virtual Sponsor Sponsor { get; set; }
    }
}
