using Crayon.API.Model;
using System.Security.Claims;

namespace Crayon.API.Services.Contracts
{
    public interface ImUserService
    {
        public IEnumerable<Account> GetUserAccounts(ClaimsPrincipal user);
    }
}
