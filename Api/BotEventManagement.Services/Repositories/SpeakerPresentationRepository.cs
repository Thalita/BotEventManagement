using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Response;

namespace EventManager.Services.Repositories
{
    public class SpeakerPresentationRepository : ISpeakerPresentationRepository
    {
        private EventManagerContext _EventManagerContext;

        public SpeakerPresentationRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(SpeakerPresentationRequest speakerPresentation)
        {
            _EventManagerContext.SpeakerPresentation.Add(new SpeakerPresentation
            {
                PresentationId = speakerPresentation.PresentationId,
                SpeakerId = speakerPresentation.SpeakerId
            });

            _EventManagerContext.SaveChanges();
        }

        public void Delete(SpeakerPresentationRequest speakerPresentation)
        {
            var result = _EventManagerContext.SpeakerPresentation
                                                             .Where(x => x.SpeakerId == speakerPresentation.SpeakerId
                                                                 && x.PresentationId == speakerPresentation.PresentationId)
                                                             .FirstOrDefault();

            _EventManagerContext.SpeakerPresentation.Remove(result);

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<SpeakerResponse> Select(Expression<Func<Speaker, bool>> query)
        {
            throw new NotImplementedException();
        }

        public void Update(SpeakerPresentationRequest element)
        {
            throw new NotImplementedException();
        }
    }
}
