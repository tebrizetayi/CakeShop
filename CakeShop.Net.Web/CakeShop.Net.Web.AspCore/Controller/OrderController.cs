using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Controllers
{
    public class OrderController: Controller
    {
        private IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork, IShoppingCartBs shoppingCartBs)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.SetShoppingCart(shoppingCartBs);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(OrderVM orderVm)
        {
            if (_unitOfWork.ShoppingCartBs.ShoppingCartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                var orderDto = Transformation.Convert<OrderVM, OrderDto>(orderVm);
                _unitOfWork.OrderBs.CreateOrder(orderDto,_unitOfWork.ShoppingCartBs);
                _unitOfWork.ShoppingCartBs.ClearCart();
                _unitOfWork.Commit();
                return RedirectToAction("CheckoutComplete");
            }
            return View(orderVm);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = string.Format("{0}, thanks for your order. You'll soon enjoy our delicious pies!", HttpContext.User.Identity.Name);
            return View();
        }
    }
}
