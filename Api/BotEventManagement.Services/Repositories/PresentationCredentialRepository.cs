using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class PresentationCredentialRepository : Repository<PresentationCredential>
    {
        public PresentationCredentialRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
