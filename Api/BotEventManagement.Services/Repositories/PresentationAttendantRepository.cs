using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class PresentationAttendantRepository : Repository<PresentationAttendant>
    {
        public PresentationAttendantRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
