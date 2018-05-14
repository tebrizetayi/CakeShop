using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CakeShop.Net.BS.Implementation
{
    /// <summary>
    /// UserManagementBs is responsible for Login with already exist and registering a new user
    /// </summary>
    public class UserManagementBs : IUserManagementBS
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// Constructor for UserManagementBs
        /// </summary>
        /// <param name="userManager">Provides the APIs for managing user in a persistence store.</param>
        /// <param name="signInManager">Provides the APIs for user sign in.</param>
        public UserManagementBs(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Login for existing user.
        /// </summary>
        /// <param name="username">Username of existing user.</param>
        /// <param name="password">Password of existing user.</param>
        /// <returns></returns>
        public async Task<SignInResult> Login(string username, string password)
        {
            var user = _userManager.FindByNameAsync(username);
            if (user == null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            return result;
        }
        /// <summary>
        /// Function for creating a new user.
        /// </summary>
        /// <param name="username">Username of a new user.</param>
        /// <param name="password">Password of a new user.</param>
        /// <returns></returns>
        public async Task<IdentityResult> Register(string username, string password)
        {
            IdentityUser identityUser = new IdentityUser(username);
            var result = await _userManager.CreateAsync(identityUser, password);
            return result;
        }

        /// <summary>
        /// Function for logging off.
        /// </summary>
        /// <returns></returns>
        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
