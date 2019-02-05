using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class CredentialRepository : Repository<Credential>
    {
        public CredentialRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
