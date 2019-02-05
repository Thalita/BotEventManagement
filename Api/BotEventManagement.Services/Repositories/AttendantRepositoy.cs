using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class AttendantRepository : Repository<Attendant>
    {
        public AttendantRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
