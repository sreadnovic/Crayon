using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Endpoints
{
    public static class LicenceEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapPost("/ordersoftwarelicence", (ImAccountSoftwareServiceService service, ClaimsPrincipal user, int serviceId, DateTime validTo) =>
            {
                service.OrderLicence(user, serviceId, validTo);
            }).RequireAuthorization();

            app.MapGet("/getpurchasedlicences", (ImAccountSoftwareServiceService service, ClaimsPrincipal user) =>
            {
                service.GetPurchasedLicences(user);
            }).RequireAuthorization();

            app.MapPost("/extendlicence", (ImAccountSoftwareServiceService service, ClaimsPrincipal user, int licenceId, DateTime validTo) =>
            {
                service.ExtendLicence(user, licenceId, validTo);
            }).RequireAuthorization();
        }
    }
}
