using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Persistence.Repositories
{
    public class SpeakerPresentationRepository : Repository<SpeakerPresentation>
    {
        public SpeakerPresentationRepository(EventManagerContext context) : base(context)
        {
        }
    }
}
