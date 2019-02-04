using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Services.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private EventManagerContext _EventManagerContext;

        public CredentialRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(CredentiaRequest element)
        {
            var credential = new Credential
            {
                Name = element.Name,
                EventId = element.EventId
            };

            _EventManagerContext.Credential.Add(credential);
            _EventManagerContext.SaveChanges();
        }

        public void Delete(CredentiaRequest element)
        {
            var result = _EventManagerContext.Credential.FirstOrDefault(c => c.CredentialId == element.CredentialId);

            _EventManagerContext.Credential.Remove(result);

            _EventManagerContext.PresentationCredential.RemoveRange(_EventManagerContext.PresentationCredential
                                                                    .Where(p => p.CredentialId == result.CredentialId));

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<CredentialResponse> Select(Expression<Func<Credential, bool>> query)
        {
            var credentials = new List<CredentialResponse>();

            foreach (var item in _EventManagerContext.Credential.Where(query))
            {
                credentials.Add(new CredentialResponse
                {
                    CredentialId = item.CredentialId,
                    EventId = item.EventId,
                    Name = item.Name,
                    Presentations = (from p in item.PresentationCredentials
                                    .Where(c => c.CredentialId == item.CredentialId)
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
                                            Category = p.Category                                                             
                                        }).ToList()
                });
            }
            return credentials;
        }

        public void Update(CredentiaRequest element)
        {
            var credential = _EventManagerContext.Credential.FirstOrDefault(x => x.CredentialId == element.CredentialId);

            credential.Name = element.Name;

            _EventManagerContext.Entry(credential).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }
    }
}
