using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Repositories
{
    public class PresentationRepository : IPresentationRepository
    {
        private EventManagerContext _EventManagerContext;

        public PresentationRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(PresentationRequest element)
        {
            ValidateEventDate(element);

            var presentation = new Presentation
            {
                Date = element.Date,
                Description = element.Description,
                EventId = element.EventId,
                Name = element.Name,
                Category = element.Category,
                Theme = element.Theme,
                Local = element.Local
            };

            var inserted = _EventManagerContext.Presentation.Add(presentation).Entity;

            if (element.CredentialIds != null && element.CredentialIds.Count() > 0)
            {
                var credentials = element.CredentialIds.Select(id => new PresentationCredential
                {
                    CredentialId = id,
                    PresentationId = inserted.PresentationId
                });

                _EventManagerContext.PresentationCredential.AddRange(credentials);
            }

            _EventManagerContext.SaveChanges();
        }

        public void Delete(PresentationRequest element)
        {
            var result = _EventManagerContext.Presentation.Where(x => x.PresentationId == element.PresentationId).First();

            _EventManagerContext.Presentation.Remove(result);

            _EventManagerContext.PresentationCredential.RemoveRange(_EventManagerContext.PresentationCredential
                                                                    .Where(p => p.PresentationId == result.PresentationId));

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<PresentationResponse> Select(Expression<Func<Presentation, bool>> query)
        {
            var presentations = new List<PresentationResponse>();

            foreach (var item in _EventManagerContext.Presentation.Where(query).ToList())
            {
                presentations.Add(new PresentationResponse
                {
                    PresentationId = item.PresentationId,
                    Date = item.Date,
                    Description = item.Description,
                    Name = item.Name,
                    EventId = item.EventId,
                    Theme = item.Theme,
                    Category = item.Category,
                    Local = item.Local
                });
            }

            return presentations;
        }

        public void Update(PresentationRequest element)
        {
            ValidateEventDate(element);

            var Presentation = _EventManagerContext.Presentation.Where(x => x.PresentationId == element.PresentationId).FirstOrDefault();

            Presentation.Date = element.Date;
            Presentation.Description = element.Description;
            Presentation.Name = element.Name;
            Presentation.Category = element.Category;
            Presentation.Local = element.Local;
            Presentation.Theme = element.Theme;

            _EventManagerContext.Entry(Presentation).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }

        private void ValidateEventDate(PresentationRequest element)
        {
            var @event = _EventManagerContext.Event.First(e => e.EventId == element.EventId);

            if (element.Date > @event.EndDate || element.Date < @event.StartDate)
                throw new Exception("presentation is outside the event date");
        }
    }
}
