using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Repositories
{
    public class PresentationCredentialRepository : IPresentationCredentialRepository
    {
        private EventManagerContext _EventManagerContext;

        public PresentationCredentialRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(PresentationCredentialRequest element)
        {
            _EventManagerContext.PresentationCredential.Add(new PresentationCredential
            {
                PresentationId = element.PresentationId,
                CredentialId = element.CredentialId
            });

            _EventManagerContext.SaveChanges();
        }

        public void Delete(PresentationCredentialRequest element)
        {
            var result = _EventManagerContext.PresentationCredential.Where(x => x.CredentialId == element.CredentialId
                                                                                && x.PresentationId == element.PresentationId
                                                                           ).FirstOrDefault();

            _EventManagerContext.PresentationCredential.Remove(result);
            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<PresentationCredentialResponse> Select(Expression<Func<Credential, bool>> query)
        {
            throw new NotImplementedException();
        }

        public void Update(PresentationCredentialRequest element)
        {
            throw new NotImplementedException();
        }
    }
}
