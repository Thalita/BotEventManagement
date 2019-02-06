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

            CreateMap<PresentationCredential, PresentationCredentialResponse>();
            CreateMap<Speaker, SpeakerResponse>();
            CreateMap<Sponsor, SponsorResponse>();


            CreateMap<Credential, CredentialResponse>()
             .ForMember(dest => dest.Presentations,
                        opt => opt.MapFrom(src => src.PresentationCredentials.Select(p => p.Presentation)));

            CreateMap<Presentation, PresentationResponse>()
                 .ForMember(dest => dest.Credentials,
                            opt => opt.MapFrom(src => src.PresentationCredentials.Select(c => c.Credential)));

            CreateMap<Attendant, AttendantResponse>()
                 .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Credential.EventId))
                 .ForMember(dest => dest.Presentations,
                            opt => opt.MapFrom(src => src.PresentationAttendants.Select(p => p.Presentation)));


            CreateMap<AttendantRequest, Attendant>();
            CreateMap<AttendantPresentationRequest, PresentationAttendant>();
        }
    }
}
