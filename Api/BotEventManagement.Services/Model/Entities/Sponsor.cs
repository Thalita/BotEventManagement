using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Services.Model.Entities
{
    public class Sponsor
    {

        [Key]
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string PageURL { get; set; }
        public string UploadedPhoto { get; set; }

        public virtual IList<EventSponsor> EventSponsors { get; set; }

    }

}
