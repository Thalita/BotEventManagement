using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class Credential
    {
        [Key]
        public int CredentialId { get; set; }
        public string Name { get; set; }

        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public virtual IList<PresentationCredential> PresentationCredentials { get; set; }
    }
}
