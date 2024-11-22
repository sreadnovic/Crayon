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
                try
                {
                    service.OrderLicence(user, serviceId, validTo);
                    return Results.Ok();
                } catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).RequireAuthorization();

            app.MapGet("/getpurchasedlicences", (ImAccountSoftwareServiceService service, ClaimsPrincipal user) =>
            {
                return service.GetPurchasedLicences(user);
            }).RequireAuthorization();

            app.MapPost("/extendlicence", (ImAccountSoftwareServiceService service, ClaimsPrincipal user, int licenceId, DateTime validTo) =>
            {
                try
                {
                    service.ExtendLicence(user, licenceId, validTo);
                    return Results.Ok();
                } catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            }).RequireAuthorization();
        }
    }
}
