using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class Attendant
    {
        [Key]
        public int AttendantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [ForeignKey("CredentialId")]
        public int CredentialId { get; set; }
        public virtual Credential Credential { get; set; }

        public virtual IList<PresentationAttendant> PresentationAttendants { get; set; }

    }
}

