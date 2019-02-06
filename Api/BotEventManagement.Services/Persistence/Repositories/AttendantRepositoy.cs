using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class AttendantRepository : Repository<Attendant>
    {
        public AttendantRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
