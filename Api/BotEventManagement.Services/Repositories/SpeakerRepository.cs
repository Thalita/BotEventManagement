using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class SpeakerRepository : Repository<Speaker>
    {
        public SpeakerRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
