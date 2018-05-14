using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Model.VM
{
    public class OrderDetailVM
    {
        public Guid Id { get; set; }
        public Guid Order { get; set; }
        public Guid Pie { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
