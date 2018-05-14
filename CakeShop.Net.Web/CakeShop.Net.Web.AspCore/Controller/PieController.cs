using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Net.BS.Implementation;
using CakeShop.Net.Web.AspCore;
using CakeShop.Net.Model;
using CakeShop.Net.Model.DTO;
using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.VM;

namespace CakeShop.Net.Web.AspCore
{
    public class PieController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PieController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var lstPieDto = _unitOfWork.PieBs.GetAll();
            var lstPieVm = Transformation.Convert<PieDto, PieVM>(lstPieDto);
            return View(lstPieVm);
        }

        public IActionResult Add(PieVM PieVm)
        {
            if (ModelState.IsValid)
            {
                var PieDto = Transformation.Convert<PieVM, PieDto>(PieVm);
                _unitOfWork.PieBs.Add(PieDto);
                _unitOfWork.Commit();
                return View("Index");
            }
            return View(PieVm);
        }

        public IActionResult Edit(PieVM PieVm)
        {
            if (ModelState.IsValid)
            {
                var PieDto = Transformation.Convert<PieVM, PieDto>(PieVm);
                _unitOfWork.PieBs.Edit(PieDto);
                _unitOfWork.Commit();
                return View("Index");
            }
            return View(PieVm);
        }

        public IActionResult Delete(Guid id)
        {
            _unitOfWork.PieBs.Delete(id);
            _unitOfWork.Commit();
            return View("Index");
        }

        public IActionResult PieOfTheWeek()
        {
            var lstPieDto = _unitOfWork.PieBs.FindBy(x => x.IsPieOfTheWeek == true);
            var lstPieVm = Transformation.Convert<PieDto, PieVM>(lstPieDto);
            return View("Index",lstPieVm);
        }

        public IActionResult Details(Guid id)
        {
            var pieDto = _unitOfWork.PieBs.GetById(id);

            if (pieDto == null)
                return NotFound();
            var pieVm = Transformation.Convert<PieDto, PieVM>(pieDto);

            return View(pieVm);
        }
    }
}