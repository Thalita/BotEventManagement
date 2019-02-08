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

            CreateMap<Credential, PresentationCredentialResponse>()
             .ForPath(dest => dest.Credential.CredentialId,
                            opt => opt.MapFrom(src => src.CredentialId))
             .ForPath(dest => dest.Credential.EventId,
                            opt => opt.MapFrom(src => src.EventId))
             .ForPath(dest => dest.Credential.Name,
                            opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Presentations,
                            opt => opt.MapFrom(src => src.PresentationCredentials.Select(p => p.Presentation)));

            CreateMap<Speaker, SpeakerResponse>();
            CreateMap<Sponsor, SponsorResponse>();

            CreateMap<Credential, CredentialResponse>();

            CreateMap<Presentation, PresentationResponse>();

            CreateMap<Attendant, AttendantResponse>()
                 .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Credential.EventId))
                 .ForMember(dest => dest.Presentations,
                            opt => opt.MapFrom(src => src.PresentationAttendants.Select(p => p.Presentation)));

            CreateMap<AttendantRequest, Attendant>();

            CreateMap<AttendantPresentationRequest, PresentationAttendant>();

            CreateMap<PresentationCredentialRequest, PresentationCredential>();
        }
    }
}
