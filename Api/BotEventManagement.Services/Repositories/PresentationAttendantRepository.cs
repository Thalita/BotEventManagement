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
    public class PresentationAttendantRepository : IAttendantPresentationRepository
    {
        private EventManagerContext _EventManagerContext;

        public PresentationAttendantRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(AttendantPresentationRequest element)
        {
            _EventManagerContext.PresentationAttendant.Add(new PresentationAttendant
            {
                PresentationId = element.PresentationId,
                AttendantId = element.AttendantId
            });

            _EventManagerContext.SaveChanges();
        }

        public void Delete(AttendantPresentationRequest presentationAttendants)
        {
            PresentationAttendant result = _EventManagerContext.PresentationAttendant.Where(x => x.AttendantId == presentationAttendants.AttendantId
                                                                                                && x.PresentationId == presentationAttendants.PresentationId).FirstOrDefault();

            _EventManagerContext.PresentationAttendant.Remove(result);

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<AttendantResponse> Select(Expression<Func<PresentationAttendant, bool>> query)
        {
            var presentationAttendant = _EventManagerContext.PresentationAttendant
                                                     .Include(x => x.Presentation)
                                                     .ThenInclude(x=> x.PresentationCredentials)
                                                     .ThenInclude(x => x.Credential)
                                                     .Where(query);

            var result = new AttendantResponse
            {
                AttendantId = presentationAttendant.First().AttendantId,
                EventId = presentationAttendant.First().Presentation.EventId,
                Email = presentationAttendant.First().Attendant.Email,
                Name = presentationAttendant.First().Attendant.Name
            };


            foreach (var item in presentationAttendant)
            {
                //Todo code review
                var credentials = from c in item.Presentation.PresentationCredentials.Select(x => x.Credential)
                                  select new CredentialResponse
                                  {
                                      CredentialId = c.CredentialId,
                                      EventId = c.EventId,
                                      Name = c.Name
                                  };

                result.Presentations.Add(new PresentationResponse
                {
                    PresentationId = item.PresentationId,
                    EventId = item.Presentation.EventId,
                    Name = item.Presentation.Name,
                    Description = item.Presentation.Description,
                    Date = item.Presentation.Date,
                    Local = item.Presentation.Local,
                    Theme = item.Presentation.Theme,
                    Category = item.Presentation.Category,
                    Credentials = credentials.ToList()
                });              

            }

            var list = new List<AttendantResponse>();
            list.Add(result);

            return list;
        }

        public void Update(AttendantPresentationRequest element)
        {
            throw new NotImplementedException();
        }
    }
}
