using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class UserMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<UserMenuItem>
            {
                new UserMenuItem()
                {
                    DisplayValue = "User management",
                    ActionValue = "Index"

                },
                new UserMenuItem()
                {
                    DisplayValue = "Role management",
                    ActionValue = "Index"
                }};

            return View(menuItems);
        }
    }

    public class UserMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}
