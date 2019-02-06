using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class SponsorRepository : Repository<Sponsor>
    {
        public SponsorRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
