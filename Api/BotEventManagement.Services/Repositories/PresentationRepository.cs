using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class PresentationRepository : Repository<Presentation>
    {
        public PresentationRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
