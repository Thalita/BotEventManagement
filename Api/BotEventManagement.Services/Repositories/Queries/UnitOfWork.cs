using EventManager.Services.Interfaces;
using EventManager.Services.Model.Database;
using EventManager.Services.Model.Entities;
using System;

namespace EventManager.Services.Repositories.Queries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventManagerContext _context;

        public UnitOfWork(EventManagerContext context) 
        {
            _context = context;

            Attendant = new AttendantRepository(_context);
            Credential = new CredentialRepository(_context);
            Event = new EventRepository(_context);
            PresentationAttendant = new PresentationAttendantRepository(_context);
            PresentationCredential = new PresentationCredentialRepository(_context);
            Presentation = new PresentationRepository(_context);
            Speaker = new SpeakerRepository(_context);
            SpeakerPresentation = new SpeakerPresentationRepository(_context);
            Sponsor = new SponsorRepository(_context);
        }

        public IRepository<Attendant> Attendant { get; private set; }

        public IRepository<Credential> Credential { get; private set; }

        public IRepository<Event> Event { get; private set; }

        public IRepository<PresentationAttendant> PresentationAttendant { get; private set; }

        public IRepository<PresentationCredential> PresentationCredential { get; private set; }

        public IRepository<Presentation> Presentation { get; private set; }

        public IRepository<Speaker> Speaker { get; private set; }

        public IRepository<SpeakerPresentation> SpeakerPresentation { get; private set; }

        public IRepository<Sponsor> Sponsor { get; private set; }


        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
