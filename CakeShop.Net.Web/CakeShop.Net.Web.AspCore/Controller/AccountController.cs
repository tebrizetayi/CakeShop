using CakeShop.Net.BS.Interface;
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
        private readonly IUserManagementBS _userBs;

        public AccountController(IUserManagementBS userBS)
        {
            _userBs = userBS;
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
                var result = await _userBs.Login(loginVm.UserName, loginVm.Password);
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
                var result = await _userBs.Register(loginVm.UserName, loginVm.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userBs.LogOff();
            return RedirectToAction("Index", "Home");
        }
    }
}
