using Crayon.API.DB;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public static class UserEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/useraccounts", (ClaimsPrincipal user) =>
            {
                var bearerId = user.Claims.First(x => x.Type == "jti").Value;

                return DbMock.Accounts.Where(x => x.BearerId == bearerId).Select(x => x.Name);
            }).RequireAuthorization();
        }
    }
}
