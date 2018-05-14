using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Implementation
{
    public class PieBs : BaseBs<PieDto, Pie>, IPieBs
    {
        public PieBs(AppDbContext iDbConnection):base(iDbConnection)
        {
        }
    }
}
