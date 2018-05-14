using CakeShop.Net.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Interface
{
    public interface IOrderBs : IBaseBs<OrderDto>
    {
        void CreateOrder(OrderDto orderDto, IShoppingCartBs shoppingCartBs);
    }
}
