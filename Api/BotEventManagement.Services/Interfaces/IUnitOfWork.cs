using EventManager.Services.Model.Entities;
using System;

namespace EventManager.Services.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Attendant> Attendant { get; }
        IRepository<Credential> Credential { get; }
        IRepository<Event> Event { get; }
        IRepository<PresentationAttendant> PresentationAttendant { get; }
        IRepository<PresentationCredential> PresentationCredential { get; }
        IRepository<Presentation> Presentation { get; }
        IRepository<Speaker> Speaker { get; }
        IRepository<SpeakerPresentation> SpeakerPresentation { get; }
        IRepository<Sponsor> Sponsor { get; }

        int Save();
    }
}
