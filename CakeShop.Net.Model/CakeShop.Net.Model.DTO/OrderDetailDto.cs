using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.Model.DTO
{
    public class OrderDetailDto:BaseDto
    {
        public int Amount { get; set; }
        public PieDto Pie { get; set; }
        public OrderDto Order { get; set; }
        public decimal Price { get; set; }
    }
}
