using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class Sponsor
    {
        [Key]
        public int SponsorId { get; set; }
        [Required]
        public string Name { get; set; }
        public string PageURL { get; set; }
        public string UploadedPhoto { get; set; }

        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
    }
}
