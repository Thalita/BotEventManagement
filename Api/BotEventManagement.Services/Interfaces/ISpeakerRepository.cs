using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;

namespace EventManager.Services.Interfaces
{
    public interface ISpeakerRepository : IRepository<SpeakerRequest, SpeakerResponse, Speaker>
    {
    }
}
