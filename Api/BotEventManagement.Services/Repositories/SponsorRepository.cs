using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class SponsorRepository : Repository<Sponsor>
    {
        public SponsorRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
