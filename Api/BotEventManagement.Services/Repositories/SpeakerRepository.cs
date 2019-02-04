using EventManager.Services.Extensions;
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
    public class SpeakerRepository : ISpeakerRepository
    {
        private EventManagerContext _EventManagerContext;

        public SpeakerRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(SpeakerRequest element)
        {
            var speaker = new Speaker
            {
                Biography = element.Biography,
                Name = element.Name,
                UploadedPhoto = element.UploadedPhoto
            };

            _EventManagerContext.Speaker.Add(speaker);
            _EventManagerContext.SaveChanges();
        }

        public void Delete(SpeakerRequest element)
        {
            Speaker result = _EventManagerContext.Speaker.Where(x => x.SpeakerId == element.SpeakerId).First();
            _EventManagerContext.Speaker.Remove(result);

            _EventManagerContext.SaveChanges();
        }

        public IEnumerable<SpeakerResponse> Select(Expression<Func<Speaker, bool>> query)
        {
            var speakers = new List<SpeakerResponse>();

            var speakerList = _EventManagerContext.Speaker.Include(sp => sp.SpeakerPresentations)
                                                          .ThenInclude(p => p.Presentation)
                                                          .ThenInclude(pc => pc.PresentationCredentials)
                                                          .ThenInclude(c => c.Credential)
                                                          .Where(query);

            foreach (var item in speakerList)
            {

                var presentations = from p in item.SpeakerPresentations
                                    select new PresentationResponse
                                    {
                                        PresentationId = p.PresentationId,
                                        EventId = p.Presentation.EventId,
                                        Description = p.Presentation.Description,
                                        Category = p.Presentation.Category,
                                        Date = p.Presentation.Date,
                                        Theme = p.Presentation.Theme,
                                        Local = p.Presentation.Local,
                                        Name = p.Presentation.Name,
                                        Credentials = p.Presentation.PresentationCredentials
                                                       .Select(x => x.Credential).ToCredentialResponse().ToList()
                                    };


                speakers.Add(new SpeakerResponse
                {
                    SpeakerId = item.SpeakerId,
                    Biography = item.Biography,
                    Name = item.Name,
                    UploadedPhoto = item.UploadedPhoto,
                    Presentations = presentations.ToList()
                });


            }

            return speakers;
        }

        public void Update(SpeakerRequest element)
        {
            var speaker = _EventManagerContext.Speaker.Where(x => x.SpeakerId == element.SpeakerId).FirstOrDefault();

            speaker.UploadedPhoto = element.UploadedPhoto;
            speaker.Name = element.Name;
            speaker.Biography = element.Biography;

            _EventManagerContext.Entry(speaker).State = EntityState.Modified;
            _EventManagerContext.SaveChanges();
        }

    }
}
