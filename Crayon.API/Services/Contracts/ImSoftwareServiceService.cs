using Crayon.API.Model;
using System.Security.Claims;

namespace Crayon.API.Services.Contracts
{
    public interface ImSoftwareServiceService
    {
        public List<SoftwareService> GetAllSoftwareServices(ClaimsPrincipal user);
        public void CancelSoftwareSeervice(ClaimsPrincipal user, int serviceId);
    }
}
