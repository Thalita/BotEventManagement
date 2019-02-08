using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class PresentationCredentialRepository : Repository<PresentationCredential>
    {
        public PresentationCredentialRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
