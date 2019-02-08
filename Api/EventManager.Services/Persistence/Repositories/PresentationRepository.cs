using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class PresentationRepository : Repository<Presentation>
    {
        public PresentationRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
