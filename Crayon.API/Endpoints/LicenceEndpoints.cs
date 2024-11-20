using Crayon.API.DB;
using Crayon.API.Extensions;
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
                var softwareService = DbMock.SoftwareServices.First(x => x.Id == serviceId);

                var licence = new SoftwareServiceLicence
                {
                    Id = DbMock.SoftwareServiceInstances.Max(x => x.Id) + 1,
                    SoftwareService = softwareService,
                    ValidTo = validTo
                };
                DbMock.SoftwareServiceInstances.Add(licence);

                DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId()).Licences.Add(licence);
            }).RequireAuthorization();

            app.MapGet("/getpurchasedlicences", (ClaimsPrincipal user) =>
            {
                return DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId()).Licences;
            }).RequireAuthorization();

            app.MapPost("/extendlicence", (ClaimsPrincipal user, int licenceId, DateTime validTo) =>
            {
                DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId())
                .Licences.First(x => x.Id == licenceId).ValidTo = validTo;
            }).RequireAuthorization();
        }
    }
}
