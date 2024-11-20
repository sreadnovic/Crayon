using Crayon.API.DB;
using System.Security.Claims;

namespace Crayon.API.Endpoints
{
    public static class SoftwareServiceEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/softwareservices", (ClaimsPrincipal user) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                return DbMock.SoftwareServices.Select(x => x.Name);
            }).RequireAuthorization();

            app.MapPost("/cancelsoftware", (ClaimsPrincipal user, int serviceId) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                DbMock.AccountServices.First(x => x.Account.BearerId == bearerId)
                .Licences.Where(x => x.SoftwareService.Id == serviceId)
                .ToList()
                .ForEach(x => x.Status = false);
            }).RequireAuthorization();

        }
    }
}
