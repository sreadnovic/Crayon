using Crayon.API.DB;
using Crayon.API.Extensions;
using System.Security.Claims;

namespace Crayon.API.Endpoints
{
    public static class SoftwareServiceEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/softwareservices", (ClaimsPrincipal user) =>
            {
                return DbMock.SoftwareServices.Select(x => x.Name);
            }).RequireAuthorization();

            app.MapPost("/cancelsoftware", (ClaimsPrincipal user, int serviceId) =>
            {
                DbMock.AccountServices.First(x => x.Account.BearerId == user.GetBearerId())
                .Licences.Where(x => x.SoftwareService.Id == serviceId)
                .ToList()
                .ForEach(x => x.Status = false);
            }).RequireAuthorization();

        }
    }
}
