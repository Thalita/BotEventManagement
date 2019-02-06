using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class CredentialRepository : Repository<Credential>
    {
        public CredentialRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
