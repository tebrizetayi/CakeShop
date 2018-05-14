using CakeShop.Net.BS.Implementation;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Web.AspCore.Components
{
    public class ShoppingCartSummary:ViewComponent
    {
        private readonly IShoppingCartBs _shoppingCartBs;

        public ShoppingCartSummary(IShoppingCartBs shoppingCartBs)
        {
            _shoppingCartBs = shoppingCartBs;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCartBs.GetShoppingCartItems();
            items = new List<ShoppingCartItemDto>() { new ShoppingCartItemDto(), new ShoppingCartItemDto() };
            var shoppingCartVm = new ShoppingCartVM()
            {
                Total = _shoppingCartBs.GetShoppingCartTotal(),
                LstShoppingCartVm = (List<ShoppingCartItemVM>)Transformation.Convert<ShoppingCartItemDto, ShoppingCartItemVM>(_shoppingCartBs.GetShoppingCartItems())
            };
            return View(shoppingCartVm);
        }
    }
}
