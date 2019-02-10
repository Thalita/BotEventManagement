using EventManager.Services.Persistence.Database;
using EventManager.Services.Model.Entities;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventManager.Services.Persistence.Repositories
{
    public class PresentationRepository : Repository<Presentation>
    {
        public PresentationRepository(EventManagerContext context) : base(context)
        {
        }

        public override IEnumerable<Presentation> Find(Expression<Func<Presentation, bool>> predicate)
        {
            var presentations = (_context as EventManagerContext).Presentation
                .Include(sp => sp.SpeakerPresentations)
                    .ThenInclude(s => s.Speaker)
                .Include(pc => pc.PresentationCredentials)
                    .ThenInclude(c => c.Credential);

            return presentations.Where(predicate);
        }
    }
}
