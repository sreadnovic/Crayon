using Crayon.API.DB;
using Crayon.API.Extensions;
using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Endpoints
{
    public static class SoftwareServiceEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/softwareservices", (ClaimsPrincipal user, ImSoftwareServiceService service) =>
            {
                return service.GetAllSoftwareServices(user).Select(x => x.Name);
            }).RequireAuthorization();

            app.MapPost("/cancelsoftware", (ClaimsPrincipal user, ImSoftwareServiceService service, int serviceId) =>
            {
                service.CancelSoftwareSeervice(user, serviceId);
            }).RequireAuthorization();

        }
    }
}
