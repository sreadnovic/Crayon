using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public static class UserEndpoints
    {
        public static void Register(WebApplication app)
        {
            app.MapGet("/useraccounts", (ClaimsPrincipal user, ImUserService userService) =>
            {
                return userService.GetUserAccounts(user).Select(x => x.Name);
            }).RequireAuthorization();
        }
    }
}
