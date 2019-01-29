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
    public class AttendantRepository : IAttendantRepository
    {
        private EventManagerContext _EventManagerContext;

        public AttendantRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(AttendantDTO element)
        {
            Attendant attendant = new Attendant
            {
                CredentialId = element.CredentialId,
                Email = element.Email,
                Name = element.Name
            };

            _EventManagerContext.Attendant.Add(attendant);
            _EventManagerContext.SaveChanges();
        }



        public void Delete(AttendantDTO element)
        {
            Attendant result = _EventManagerContext.Attendant.Where(x => x.AttendantId == element.AttendantId).First();

            _EventManagerContext.Attendant.Remove(result);

            _EventManagerContext.SaveChanges();

        }

        public IEnumerable<AttendantDTO> Select(Expression<Func<Attendant, bool>> query)
        {
            List<AttendantDTO> participantsRequests = new List<AttendantDTO>();

            foreach (var item in _EventManagerContext.Attendant.Where(query))
            {
                participantsRequests.Add(new AttendantDTO
                {
                    AttendantId = item.AttendantId,
                    Name = item.Name,
                    CredentialId = item.CredentialId,

                    Presentations = item.PresentationAttendants.Where(p => p.AttendantId == item.AttendantId)
                                                                      .Select(p => p.Presentation).ToList()
                });
            }

            return participantsRequests;
        }

        public void Update(AttendantDTO element)
        {
            var attendant = _EventManagerContext.Attendant.Where(x => x.AttendantId == element.AttendantId).FirstOrDefault();

            attendant.Name = element.Name;
            attendant.Email = element.Email;
            attendant.CredentialId = element.CredentialId;

            _EventManagerContext.Entry(attendant).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }

        public void Update(Attendant element)
        {
            throw new NotImplementedException();
        }
    }
}
