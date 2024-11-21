using Crayon.API.Model;
using System.Security.Claims;

namespace Crayon.API.Services.Contracts
{
    public interface ImAccountSoftwareServiceService
    {
        public void OrderLicence(ClaimsPrincipal user, int serviceId, DateTime validTo);
        public List<SoftwareServiceLicence> GetPurchasedLicences(ClaimsPrincipal user);
        public void ExtendLicence(ClaimsPrincipal user, int licenceId, DateTime validTo);
    }
}
