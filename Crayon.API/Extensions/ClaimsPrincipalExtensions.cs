using System.Security.Claims;

namespace Crayon.API.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetBearerId(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.First(x => x.Type == "jti").Value;
    }
}
