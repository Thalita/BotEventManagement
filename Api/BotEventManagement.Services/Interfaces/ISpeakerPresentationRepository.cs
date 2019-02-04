using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Interfaces
{
   public interface ISpeakerPresentationRepository: IRepository<SpeakerPresentationRequest, SpeakerResponse, Speaker>
    {
    }
}
