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
using EventManager.Services.Extensions;

namespace EventManager.Services.Repositories
{
    public class AttendantRepository : IAttendantRepository
    {
        private EventManagerContext _EventManagerContext;

        public AttendantRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(AttendantRequest element)
        {
            var attendant = new Attendant
            {
                CredentialId = element.CredentialId,
                Email = element.Email,
                Name = element.Name               
            };

            _EventManagerContext.Attendant.Add(attendant);
            _EventManagerContext.SaveChanges();
        }

        public void Delete(AttendantRequest element)
        {
            var result = _EventManagerContext.Attendant.Where(x => x.AttendantId == element.AttendantId).First();

            _EventManagerContext.Attendant.Remove(result);

            _EventManagerContext.PresentationAttendant.RemoveRange(_EventManagerContext.PresentationAttendant
                                                                    .Where(p => p.AttendantId == result.AttendantId));

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<AttendantResponse> Select(Expression<Func<Attendant, bool>> query)
        {
            var participantsReponse = new List<AttendantResponse>();

            foreach (var item in _EventManagerContext.Attendant.Where(query))
            {
                participantsReponse.Add(new AttendantResponse
                {
                    AttendantId = item.AttendantId,
                    Name = item.Name,
                    CredentialId = item.CredentialId,
                    Email = item.Email,
                    Presentations = (from p in item.PresentationAttendants
                                                   .Where(p => p.AttendantId == item.AttendantId)
                                                   .Select(p => p.Presentation)
                                     select new PresentationResponse
                                     {
                                         PresentationId = p.PresentationId,
                                         EventId = p.EventId,
                                         Name = p.Name,
                                         Date = p.Date,
                                         Description = p.Description,
                                         Local = p.Local,
                                         Theme = p.Theme, 
                                         Category = p.Category,
                                         Credentials = p.PresentationCredentials.Select(x => x.Credential).ToCredentialResponse().ToList()
                                     }).ToList()
                                       
                });
            }

            return participantsReponse;
        }

        public void Update(AttendantRequest element)
        {
            var attendant = _EventManagerContext.Attendant.Where(x => x.AttendantId == element.AttendantId).FirstOrDefault();

            attendant.Name = element.Name;
            attendant.Email = element.Email;
            attendant.CredentialId = element.CredentialId;

            _EventManagerContext.Entry(attendant).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }
    }
}
