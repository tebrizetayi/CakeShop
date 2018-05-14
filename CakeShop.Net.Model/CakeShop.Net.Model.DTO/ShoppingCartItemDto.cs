using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.Model.DTO
{
    public class ShoppingCartItemDto : BaseDto
    {
        public PieDto Pie { get; set; }
        public int Amount { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }

    }
}
