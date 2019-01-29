using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EventManager.Services.Model.Database;

namespace EventManager.Services.Respositories
{
    public class EventRepository : IEventRepository
    {
        private EventManagerContext _EventManagerContext;

        public EventRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(EventDTO element)
        {
            Event @event = new Event
            {
                Address = element.Address,
                Description = element.Description,
                EndDate = element.EndDate,
                Name = element.Name,
                StartDate = element.StartDate,
            };

            _EventManagerContext.Event.Add(@event);
            _EventManagerContext.SaveChanges();
        }

        public void Delete(EventDTO element)
        {
            Event @event = _EventManagerContext.Event.Where(x => x.EventId == element.Id).First();
            _EventManagerContext.Event.Remove(@event);

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<EventDTO> Select(Expression<Func<Event, bool>> query)
        {
            List<EventDTO> eventRequests = new List<EventDTO>();

            foreach (var item in _EventManagerContext.Event.Where(query))
            {
                eventRequests.Add(new EventDTO
                {
                    Address = item.Address,
                    Description = item.Description,
                    EndDate = item.EndDate,
                    Name = item.Name,
                    StartDate = item.StartDate,
                    Id = item.EventId
                });
            }
            return eventRequests;
        }

        public void Update(EventDTO element)
        {
            Event @event = _EventManagerContext.Event.Where(x => x.EventId == element.Id).FirstOrDefault();

            @event.StartDate = element.StartDate;
            @event.EndDate = element.EndDate;
            @event.Name = element.Name;
            @event.Description = element.Description;
            @event.Address = element.Address;

            _EventManagerContext.Entry(@event).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }
    }
}
