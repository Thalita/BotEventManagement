using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Respositories
{
    public class PresentationRepository : IPresentationRepository
    {
        private EventManagerContext _EventManagerContext;

        public PresentationRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(PresentationDTO element)
        {
            Presentation Presentation = new Presentation
            {
                Date = element.Date,
                Description = element.Description,
                EventId = element.EventId,
                Name = element.Name

            };

            _EventManagerContext.Presentation.Add(Presentation);
            _EventManagerContext.SaveChanges();

        }

        public void Delete(PresentationDTO element)
        {
            Presentation result = _EventManagerContext.Presentation.Where(x => x.EventId == element.EventId && x.PresentationId == element.PresentationId).First();
            _EventManagerContext.Presentation.Remove(result);

            _EventManagerContext.SaveChanges();

        }

        public IEnumerable<PresentationDTO> Select(Expression<Func<Presentation, bool>> query)
        {
            List<PresentationDTO> PresentationRequests = new List<PresentationDTO>();

            foreach (var item in _EventManagerContext.Presentation.Where(query).ToList())
            {
                PresentationRequests.Add(new PresentationDTO
                {
                    PresentationId = item.PresentationId,
                    Date = item.Date,
                    Description = item.Description,
                    Name = item.Name,
                    EventId = item.EventId
                });
            }

            return PresentationRequests;
        }

        public void Update(PresentationDTO element)
        {
            var Presentation = _EventManagerContext.Presentation.Where(x => x.PresentationId == element.PresentationId).FirstOrDefault();

            Presentation.Date = element.Date;
            Presentation.Description = element.Description;
            Presentation.Name = element.Name;

            _EventManagerContext.Entry(Presentation).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }

    }
}
