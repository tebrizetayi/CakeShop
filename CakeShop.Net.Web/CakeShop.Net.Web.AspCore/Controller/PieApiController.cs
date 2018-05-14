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
    /// <summary>
    /// This is API controller for getting Pies.
    /// </summary>
    [Route("api/[controller]")]
    public class PieApiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PieApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<PieVM> LoadMorePies(int skipCount,int takeCount)
        {
            var dbPies = _unitOfWork.PieBs.GetAll().Skip(skipCount).Take(takeCount);
            var lstPieVm = Transformation.Convert<PieDto, PieVM>(dbPies);
            return lstPieVm;
        }
    }
}