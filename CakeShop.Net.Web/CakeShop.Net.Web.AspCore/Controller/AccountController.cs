using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Web.AspCore
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserManagementBS _userManagementBs;

        public AccountController(IUserManagementBS userManagementBs)
        {
            _userManagementBs = userManagementBs;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            LoginVM loginVm = new LoginVM()
            {
                ReturnUrl = returnUrl
            };
            return View(loginVm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVM loginVm)
        {
            if (ModelState.IsValid)
            {
                var result = await _userManagementBs.Login(loginVm.UserName, loginVm.Password);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVm.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(loginVm.ReturnUrl);
                }
                ModelState.AddModelError("", "Login failed!");
            }
            return View(loginVm);
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(LoginVM loginVm)
        {
            if (ModelState.IsValid)
            {
                var identityUser = Transformation.Convert<LoginVM, IdentityUser>(loginVm);
                var result = await _userManagementBs.Register(identityUser, loginVm.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userManagementBs.LogOff();
            return RedirectToAction("Index", "Home");
        }
    }
}
