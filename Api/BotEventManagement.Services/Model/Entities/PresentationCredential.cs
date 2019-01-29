using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Services.Model.Entities
{
    public class PresentationCredential
    {
        [ForeignKey("PresentationId")]
        public int PresentationId { get; set; }
        public virtual Presentation Presentation { get; set; }

        [ForeignKey("CredentialId")]
        public int CredentialId { get; set; }
        public virtual Credential Credential { get; set; }
    }
}
