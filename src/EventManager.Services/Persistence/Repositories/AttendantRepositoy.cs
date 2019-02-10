using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventManager.Services.Persistence.Repositories
{
    public class AttendantRepository : Repository<Attendant>
    {
        public AttendantRepository(EventManagerContext context) : base(context)
        {
        }

        public override IEnumerable<Attendant> Find(Expression<Func<Attendant, bool>> predicate)
        {
            var attendants = (_context as EventManagerContext).Attendant
                        .Include(c => c.Credential)
                        .Include(pa => pa.PresentationAttendants)
                          .ThenInclude(p => p.Presentation)
                          .ThenInclude(pc => pc.PresentationCredentials)
                          .ThenInclude(c => c.Credential);

            return attendants.Where(predicate);
        }

        public override void Remove(Attendant entity)
        {
            RemovePresentations(entity);
            base.Remove(entity);
        }

        private void RemovePresentations(Attendant entity)
        {
            if (entity.PresentationAttendants != null)
                foreach (PresentationAttendant p in entity.PresentationAttendants)
                    _context.Remove(p);
        }
    }
}
