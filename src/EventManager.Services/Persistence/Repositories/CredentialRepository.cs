using EventManager.Services.Model.Entities;
using EventManager.Services.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Persistence.Repositories
{
    public class CredentialRepository : Repository<Credential>
    {
        public CredentialRepository(EventManagerContext context) : base(context)
        {
        }

        public override IEnumerable<Credential> Find(Expression<Func<Credential, bool>> predicate)
        {
            var credentials = (_context as EventManagerContext).Credential
                        .Include(e => e.Event)
                        .Include(pc => pc.PresentationCredentials)
                          .ThenInclude(p => p.Presentation);

            return credentials.Where(predicate);
        }
    }
}
