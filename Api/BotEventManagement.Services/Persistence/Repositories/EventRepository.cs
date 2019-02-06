using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
