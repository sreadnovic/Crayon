using Crayon.API.DB;
using Crayon.API.Model;
using System.Security.Claims;

namespace Crayon.API.Endpoints
{
    public static class LicenceEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapPost("/ordersoftwarelicence", (ClaimsPrincipal user, int serviceId, DateTime validTo) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                var softwareService = DbMock.SoftwareServices.First(x => x.Id == serviceId);

                var licence = new SoftwareServiceLicence
                {
                    Id = DbMock.SoftwareServiceInstances.Max(x => x.Id) + 1,
                    SoftwareService = softwareService,
                    ValidTo = validTo
                };
                DbMock.SoftwareServiceInstances.Add(licence);

                DbMock.AccountServices.First(x => x.Account.BearerId == bearerId).Licences.Add(licence);
            }).RequireAuthorization();

            app.MapGet("/getpurchasedlicences", (ClaimsPrincipal user) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                return DbMock.AccountServices.First(x => x.Account.BearerId == bearerId).Licences;
            }).RequireAuthorization();

            app.MapPost("/extendlicence", (ClaimsPrincipal user, int licenceId, DateTime validTo) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                DbMock.AccountServices.First(x => x.Account.BearerId == bearerId)
                .Licences.First(x => x.Id == licenceId).ValidTo = validTo;
            }).RequireAuthorization();
        }
    }
}
