using Crayon.API.DB;
using Crayon.API.Extensions;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public static class UserEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/useraccounts", (ClaimsPrincipal user) =>
            {
                return DbMock.Accounts.Where(x => x.BearerId == user.GetBearerId()).Select(x => x.Name);
            }).RequireAuthorization();
        }
    }
}
