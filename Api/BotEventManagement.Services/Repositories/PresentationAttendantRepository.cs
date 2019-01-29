using EventManager.Services.Interfaces;
using EventManager.Services.Model.DTO;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using EventManager.Services.Model.Database;

namespace EventManager.Services.Respositories
{
    public class PresentationAttendantRepository : IUserPresentationsRepository
    {
        private EventManagerContext _EventManagerContext;

        public PresentationAttendantRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(AttendantPresentationDTO userPresentations)
        {
            _EventManagerContext.PresentationAttendant.Add(new PresentationAttendant
            {
                PresentationId = userPresentations.PresentationId,
                AttendantId = userPresentations.UserId
            });

            _EventManagerContext.SaveChanges();
        }

        public void Delete(AttendantPresentationDTO userPresentations)
        {
            PresentationAttendant result = _EventManagerContext.PresentationAttendant.Where(x => x.AttendantId == userPresentations.UserId
                                                                                                && x.PresentationId == userPresentations.PresentationId).FirstOrDefault();

            _EventManagerContext.PresentationAttendant.Remove(result);

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<PresentationDTO> Select(Expression<Func<PresentationAttendant, bool>> query)
        {

            List<PresentationDTO> userPresentationsResponses = new List<PresentationDTO>();

            foreach (var item in _EventManagerContext.PresentationAttendant.Include(x => x.Presentation).Where(query))
            {
                userPresentationsResponses.Add(new PresentationDTO
                {
                    PresentationId = item.Presentation.PresentationId,
                    Date = item.Presentation.Date,
                    Description = item.Presentation.Description,
                    Name = item.Presentation.Name,
                    EventId = item.Presentation.EventId
                });
            }

            return userPresentationsResponses;
        }

        public void Update(AttendantPresentationDTO element)
        {
            throw new NotImplementedException();
        }
    }
}
