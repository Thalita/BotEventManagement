using EventManager.Services.Model.Entities;
using EventManager.Services.Persistence.Database;

namespace EventManager.Services.Persistence.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
