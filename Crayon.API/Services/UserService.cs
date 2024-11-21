using Crayon.API.DB;
using Crayon.API.Extensions;
using Crayon.API.Model;
using Crayon.API.Services.Contracts;
using System.Security.Claims;

namespace Crayon.API.Services
{
    public class UserService : ImUserService
    {
        public IEnumerable<Account> GetUserAccounts(ClaimsPrincipal user)
            => DbMock.Accounts.Where(x => x.BearerId == user.GetBearerId());
    }
}
