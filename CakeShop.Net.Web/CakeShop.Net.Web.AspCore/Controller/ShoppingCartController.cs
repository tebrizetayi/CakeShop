using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Net.BS.Implementation;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Net.Web.AspCore
{
    public class ShoppingCartController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ShoppingCartController(IUnitOfWork unitOfWork, IShoppingCartBs shoppingCartBs)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.SetShoppingCart(shoppingCartBs);
        }

        public IActionResult Index()
        {
            var items = _unitOfWork.ShoppingCartBs.GetShoppingCartItems();
            _unitOfWork.ShoppingCartBs.ShoppingCartItems = items;
            ShoppingCartVM shoppingCartVm = new ShoppingCartVM()
            {
                LstShoppingCartVm = (List<ShoppingCartItemVM>)Transformation.Convert<ShoppingCartItemDto, ShoppingCartItemVM>(_unitOfWork.ShoppingCartBs.GetShoppingCartItems()),
                Total = _unitOfWork.ShoppingCartBs.GetShoppingCartTotal()
            };

            AssignViewBags();
            return View(shoppingCartVm);
        }

        public RedirectToActionResult AddToShoppingCart(Guid pieId)
        {
            var selectedPieDto = _unitOfWork.PieBs.GetById(pieId);
            if (selectedPieDto != null)
            {
                _unitOfWork.ShoppingCartBs.AddToCart(selectedPieDto, 1);
                _unitOfWork.Commit();
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(Guid pieId)
        {
            var selectedPieDto = _unitOfWork.PieBs.GetById(pieId);
            if (selectedPieDto != null)
            {
                _unitOfWork.ShoppingCartBs.RemoveFromCart(selectedPieDto);
                _unitOfWork.Commit();
            }
            return RedirectToAction("Index");
        }

        public void AssignViewBags()
        {
            var lstPieDto = _unitOfWork.PieBs.GetAll();
            ViewBag.LstPie = lstPieDto;
        }
    }
}