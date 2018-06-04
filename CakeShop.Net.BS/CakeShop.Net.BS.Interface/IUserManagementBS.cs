using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CakeShop.Net.BS.Interface
{
    public interface IUserManagementBS
    {
        Task<SignInResult> Login(string username, string password);
        Task<IdentityResult> Register(IdentityUser identityUser, string password);
        Task LogOff();
        IQueryable<IdentityUser> Users();
        Task<IdentityResult> Delete(string userId);
        Task<IdentityUser> GetById(string userId);
        Task<IdentityResult> Edit(IdentityUser identityUser);
    }
}
