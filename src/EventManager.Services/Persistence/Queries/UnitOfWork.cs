using EventManager.Services.Interfaces;
using EventManager.Services.Model.Entities;
using EventManager.Services.Persistence.Database;
using EventManager.Services.Persistence.Repositories;
using System;

namespace EventManager.Services.Persistence.Queries
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EventManagerContext _context;

        public UnitOfWork(EventManagerContext context)
        {
            _context = context;

            _attendantLazy = new Lazy<IRepository<Attendant>>(() => new AttendantRepository(_context));

            _credentialLazy = new Lazy<IRepository<Credential>>(() => new CredentialRepository(_context));
            _eventLazy = new Lazy<IRepository<Event>>(() => new EventRepository(_context));
            _presentationAttendantLazy = new Lazy<IRepository<PresentationAttendant>>(() => new PresentationAttendantRepository(_context));
            _presentationCredentialLazy = new Lazy<IRepository<PresentationCredential>>(() => new PresentationCredentialRepository(_context));
            _presentationLazy = new Lazy<IRepository<Presentation>>(() => new PresentationRepository(_context));
            _speakerLazy = new Lazy<IRepository<Speaker>>(() => new SpeakerRepository(_context));
            _speakerPresentationLazy = new Lazy<IRepository<SpeakerPresentation>>(() => new SpeakerPresentationRepository(_context));
            _sponsorLazy = new Lazy<IRepository<Sponsor>>(() => new SponsorRepository(_context));
        }

        #region Public properties
        public IRepository<Attendant> Attendant => _attendantLazy.Value;

        public IRepository<Credential> Credential => _credentialLazy.Value;

        public IRepository<Event> Event => _eventLazy.Value;

        public IRepository<PresentationAttendant> PresentationAttendant => _presentationAttendantLazy.Value;

        public IRepository<PresentationCredential> PresentationCredential => _presentationCredentialLazy.Value;

        public IRepository<Presentation> Presentation => _presentationLazy.Value;

        public IRepository<Speaker> Speaker => _speakerLazy.Value;

        public IRepository<SpeakerPresentation> SpeakerPresentation => _speakerPresentationLazy.Value;

        public IRepository<Sponsor> Sponsor => _sponsorLazy.Value;

        #endregion


        #region Private lazy properties

        public Lazy<IRepository<Attendant>> _attendantLazy;

        public Lazy<IRepository<Credential>> _credentialLazy;

        public Lazy<IRepository<Event>> _eventLazy;

        public Lazy<IRepository<PresentationAttendant>> _presentationAttendantLazy;

        public Lazy<IRepository<PresentationCredential>> _presentationCredentialLazy;

        public Lazy<IRepository<Presentation>> _presentationLazy;

        public Lazy<IRepository<Speaker>> _speakerLazy;

        public Lazy<IRepository<SpeakerPresentation>> _speakerPresentationLazy;

        public Lazy<IRepository<Sponsor>> _sponsorLazy;


        #endregion
        
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
