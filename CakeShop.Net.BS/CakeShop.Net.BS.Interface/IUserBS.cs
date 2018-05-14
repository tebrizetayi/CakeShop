using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CakeShop.Net.BS.Interface
{
    public interface IUserManagementBS
    {
        Task<SignInResult> Login(string username, string password);
        Task<IdentityResult> Register(string username, string password);
        Task LogOff();
    }
}
