﻿using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Repositories
{
    public class SpeakerPresentationRepository : Repository<SpeakerPresentation>
    {
        public SpeakerPresentationRepository(EventManagerContext context) : base(context)
        {
        }
    }
}