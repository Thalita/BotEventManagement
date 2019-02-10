using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;
using System;

namespace EventManager.Services.Persistence.Repositories
{
    public class SpeakerRepository : Repository<Speaker>
    {
        public SpeakerRepository(EventManagerContext context) : base(context)
        {
        } 
    }
}
