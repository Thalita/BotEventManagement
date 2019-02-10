using AutoMapper;
using EventManager.Api.DTOs.Request;
using EventManager.Api.DTOs.Response;
using EventManager.Services.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventResponse>();

            CreateMap<IEnumerable<Credential>, EventCredentialResponse>()
                        .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Select(x => x.EventId).First()))
                        .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Select(x => x.Event.Name).First()))
                        .ForMember(dest => dest.StartDate,
                            opt => opt.MapFrom(src => src.Select(x => x.Event.StartDate).First()))
                        .ForMember(dest => dest.EndDate,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.EndDate).First()))
                        .ForMember(dest => dest.Description,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.Description).First()))
                        .ForMember(dest => dest.Address,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.Address).First()))
                        .ForMember(dest => dest.Credentials,
                           opt => opt.MapFrom(src => src));

            CreateMap<IEnumerable<SpeakerPresentation>, EventSpeakerResponse>()
                        .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.EventId).First()))
                        .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.Name).First()))
                        .ForMember(dest => dest.StartDate,
                            opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.StartDate).First()))
                        .ForMember(dest => dest.EndDate,
                           opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.EndDate).First()))
                        .ForMember(dest => dest.Description,
                           opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.Description).First()))
                        .ForMember(dest => dest.Address,
                           opt => opt.MapFrom(src => src.Select(x => x.Presentation.Event.Address).First()))
                       .ForMember(dest => dest.Speakers,
                           opt => opt.MapFrom(src => src.Select(x => x.Speaker)));


            CreateMap<IEnumerable<Sponsor>, EventSponsorResponse>()
                        .ForMember(dest => dest.EventId,
                            opt => opt.MapFrom(src => src.Select(x => x.Event.EventId).First()))
                        .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.Select(x => x.Event.Name).First()))
                        .ForMember(dest => dest.StartDate,
                            opt => opt.MapFrom(src => src.Select(x => x.Event.StartDate).First()))
                        .ForMember(dest => dest.EndDate,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.EndDate).First()))
                        .ForMember(dest => dest.Description,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.Description).First()))
                        .ForMember(dest => dest.Address,
                           opt => opt.MapFrom(src => src.Select(x => x.Event.Address).First()))
                       .ForMember(dest => dest.Sponsors,
                           opt => opt.MapFrom(src => src));


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
