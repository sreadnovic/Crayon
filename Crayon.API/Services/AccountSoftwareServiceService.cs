using Crayon.API.DB;
using Crayon.API.Extensions;
using Crayon.API.Model;
using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public class AccountSoftwareServiceService : ImAccountSoftwareServiceService
    {
        public void ExtendLicence(ClaimsPrincipal user, int licenceId, DateTime validTo)
        {
            var licence = DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId())
                .Licences.FirstOrDefault(x => x.Id == licenceId);

            if (licence is null) throw new ArgumentException($"Licence with id {licenceId} does not exist!");
            if (validTo < licence.ValidTo) throw new ArgumentException($"Extension date {validTo:dd.mm.yyyy} must be greater then existing licence date {licence.ValidTo:dd.mm.yyyy}!");

            licence.ValidTo = validTo;
        }

        public List<SoftwareServiceLicence> GetPurchasedLicences(ClaimsPrincipal user)
         => DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId()).Licences;

        public void OrderLicence(ClaimsPrincipal user, int serviceId, DateTime validTo)
        {
            var softwareService = DbMock.SoftwareServices.FirstOrDefault(x => x.Id == serviceId);

            if (softwareService is null) throw new ArgumentException($"Software service with id {serviceId} does not exist!");

            var nextId = DbMock.AccountServices.SelectMany(x => x.Licences).Max(x => x.Id) + 1;

            var licence = new SoftwareServiceLicence
            {
                Id = nextId,
                SoftwareService = softwareService,
                ValidTo = validTo,
                Status = true
            };

            DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId()).Licences.Add(licence);
        }
    }
}
