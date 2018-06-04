using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Net.Web.AspCore
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserManagementBS _userManagementBs;

        public UserController(IUserManagementBS userManagementBs)
        {
            _userManagementBs = userManagementBs;
        }


        public IActionResult Index()
        {
            var lstUserIdentity = _userManagementBs.Users();
            return View(lstUserIdentity);
        }

        public IActionResult Add()
        {
            return View("_Add");
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserVM userVm)
        {
            if (!ModelState.IsValid) return View(userVm);

            var identityUser = Transformation.Convert<UserVM, IdentityUser>(userVm);
            IdentityResult result = await _userManagementBs.Register(identityUser, userVm.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("_Add",userVm);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManagementBs.GetById(id);
            if (user == null)
                return RedirectToAction("UserManagement", _userManagementBs.Users());
            var editUserVm = Transformation.Convert<IdentityUser, EditUserVM>(user);
            return View("_Edit", editUserVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserVM editUserVm)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("_Edit", editUserVm);

            var identityUser = Transformation.Convert<EditUserVM, IdentityUser>(editUserVm);
            var result = await _userManagementBs.Edit(identityUser);

            if (result.Succeeded)
                return RedirectToAction("Index");

            ModelState.AddModelError("", "User not updated, something went wrong.");

            return View("_Edit", editUserVm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string userId)
        {
            IdentityResult result = await _userManagementBs.Delete(userId);
            if (result != null && result.Succeeded)
                return RedirectToAction("Index");
            if (result == null)
            {
                ModelState.AddModelError("", "This user can't be found");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong while deleting this user.");
            }
            return View("UserManagement", _userManagementBs.Users());
        }
    }
}