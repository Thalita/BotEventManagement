using EventManager.Services.Model.DTO.Response;
using EventManager.Services.Model.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services.Extensions
{
    public static class CredentialsExtensions
    {
        public static IEnumerable<CredentialResponse> ToCredentialResponse(this IEnumerable<Credential> credentials)
        {
            var result = from c in credentials
                         select new CredentialResponse
                         {
                             CredentialId = c.CredentialId,
                             EventId = c.EventId,
                             Name = c.Name                         
                         };

            return result;
        }
    }
}
