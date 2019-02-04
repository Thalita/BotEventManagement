using EventManager.Services.Model.DTO.Request;
using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Interfaces
{
    public interface ICredentialRepository : IRepository<CredentiaRequest, CredentialResponse, Credential>
    {
    }
}
