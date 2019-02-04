using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Repositories
{
    public class SponsorRepository : ISponsorRepository
    {
        private EventManagerContext _EventManagerContext;

        public SponsorRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(SponsorRequest element)
        {
            var sponsor = new Sponsor
            {
                EventId = element.EventId,
                Name = element.Name,
                PageURL = element.PageURL,
                UploadedPhoto = element.UploadedPhoto
            };

            _EventManagerContext.Sponsor.Add(sponsor);
            _EventManagerContext.SaveChanges();
        }

        public void Delete(SponsorRequest element)
        {
            var result = _EventManagerContext.Sponsor.FirstOrDefault(s => s.SponsorId == element.SponsorId);

            _EventManagerContext.Sponsor.Remove(result);
            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<SponsorResponse> Select(Expression<Func<Sponsor, bool>> query)
        {
           var sponsors = new List<SponsorResponse>();

            foreach (var item in _EventManagerContext.Sponsor.Where(query))
            {
                sponsors.Add(new SponsorResponse
                {
                    Name = item.Name,
                    SponsorId = item.SponsorId,
                    PageURL = item.PageURL,
                    UploadedPhoto = item.UploadedPhoto
                });
            }

            return sponsors;
        }

        public void Update(SponsorRequest element)
        {
            var credential = _EventManagerContext.Sponsor.FirstOrDefault(x => x.SponsorId == element.SponsorId);

            credential.Name = element.Name;
            credential.PageURL = element.PageURL;
            credential.UploadedPhoto = element.UploadedPhoto;

            _EventManagerContext.Entry(credential).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }
    }
}
