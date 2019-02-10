using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Model.Entities;
using System.Linq;

namespace EventManager.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Event, EventResponse>();
            CreateMap<Speaker, SpeakerResponse>();
            CreateMap<Sponsor, SponsorResponse>();
            CreateMap<Credential, CredentialResponse>();
            CreateMap<Presentation, PresentationResponse>()
                .ForMember(dest => dest.Speakers,
                    opt => opt.MapFrom(src => src.SpeakerPresentations.Select(s => s.Speaker)))
                .ForMember(dest => dest.Credentials,
                    opt => opt.MapFrom(src => src.PresentationCredentials.Select(c => c.Credential)));

            CreateMap<Attendant, AttendantResponse>()
                 .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Credential.EventId))
                 .ForMember(dest => dest.Presentations,
                            opt => opt.MapFrom(src => src.PresentationAttendants.Select(p => p.Presentation)));


            CreateMap<AttendantRequest, Attendant>();
            CreateMap<AttendantPresentationRequest, PresentationAttendant>();
            CreateMap<PresentationCredentialRequest, PresentationCredential>();
            CreateMap<EventRequest, Event>();
            CreateMap<PresentationRequest, Presentation>();
            CreateMap<SpeakerPresentationRequest, SpeakerPresentation>();
            CreateMap<SponsorRequest, Sponsor>();
            CreateMap<CredentiaRequest, Credential>();
            CreateMap<SpeakerRequest, Speaker>();
        }
    }
}
