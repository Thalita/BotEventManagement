using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class EventRepository : Repository<Event>
    {
        public EventRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
