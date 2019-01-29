using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.DTO;
using EventManager.Services.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Respositories
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private EventManagerContext _EventManagerContext;

        public SpeakerRepository(EventManagerContext EventManagerContext)
        {
            _EventManagerContext = EventManagerContext;
        }

        public void Create(SpeakerDTO element)
        {
            Speaker speaker = new Speaker
            {
                Biography = element.Biography,
                Name = element.Name,
                UploadedPhoto = element.UploadedPhoto
            };

            _EventManagerContext.Speaker.Add(speaker);
            _EventManagerContext.SaveChanges();
        }


        public void Delete(SpeakerDTO element)
        {
            Speaker result = _EventManagerContext.Speaker.Where(x => x.SpeakerId == element.SpeakerId).First();
            _EventManagerContext.Speaker.Remove(result);

            _EventManagerContext.SaveChanges();

        }

        public IEnumerable<SpeakerDTO> Select(Expression<Func<Speaker, bool>> query)
        {
            List<SpeakerDTO> speakersRequests = new List<SpeakerDTO>();

            foreach (var item in _EventManagerContext.Speaker.Include(x => x.SpeakerPresentations)
                                                                .ThenInclude(x => x.Presentation).Where(query))
            {
                speakersRequests.Add(new SpeakerDTO
                {
                    Biography = item.Biography,
                    Name = item.Name,
                    SpeakerId = item.SpeakerId,
                    UploadedPhoto = item.UploadedPhoto
                });
            }

            return speakersRequests;
        }

        public void Update(SpeakerDTO element)
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
