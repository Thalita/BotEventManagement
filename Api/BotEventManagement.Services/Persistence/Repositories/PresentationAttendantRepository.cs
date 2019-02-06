using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class PresentationAttendantRepository : Repository<PresentationAttendant>
    {
        public PresentationAttendantRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
