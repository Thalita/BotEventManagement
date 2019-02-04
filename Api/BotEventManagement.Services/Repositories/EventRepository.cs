using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Response;

namespace EventManager.Services.Repositories
{
    public class EventRepository : IEventRepository
    {
        private EventManagerContext _EventManagerContext;

        public EventRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(EventRequest element)
        {
            var @event = new Event
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

        public void Delete(EventRequest element)
        {
            var @event = _EventManagerContext.Event.Where(x => x.EventId == element.Id).First();
            _EventManagerContext.Event.Remove(@event);
            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<EventResponse> Select(Expression<Func<Event, bool>> query)
        {
           var eventRequests = new List<EventResponse>();

            foreach (var item in _EventManagerContext.Event.Where(query))
            {
                eventRequests.Add(new EventResponse
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

        public void Update(EventRequest element)
        {
            var @event = _EventManagerContext.Event.Where(x => x.EventId == element.Id).FirstOrDefault();

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
