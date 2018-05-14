using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.Model.VM;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Net.Web.AspCore
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var lstPieDto = _unitOfWork.PieBs.FindBy(x => x.IsPieOfTheWeek == true);
            var lstPieVm = Transformation.Convert<PieDto, PieVM>(lstPieDto);
            return View("Index", lstPieVm);
        }
    }
}