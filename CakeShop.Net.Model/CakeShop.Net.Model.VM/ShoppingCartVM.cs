using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Net.Model.VM
{
    public class ShoppingCartVM
    {
        public List<ShoppingCartItemVM> LstShoppingCartVm { get; set; }
        public decimal Total { get;set;}
    }
}
