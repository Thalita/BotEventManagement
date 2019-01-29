using EventManager.Services.Model.Entities;
using EventManager.Services.Model.DTO;

namespace EventManager.Services.Interfaces
{
    public interface IPresentationRepository : IRepository<PresentationDTO, PresentationDTO, Presentation>
    {
    }
}
