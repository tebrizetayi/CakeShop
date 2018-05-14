using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Implementation
{
    public class OrderBs : BaseBs<OrderDto, Order>, IOrderBs
    {
        public OrderBs(AppDbContext iDbConnection) : base(iDbConnection)
        {
        }

        /// <summary>
        /// Creates Order for given shopping cart.
        /// </summary>
        /// <param name="orderDto">Order details</param>
        /// <param name="shoppingCartBs">Shoping cart that is purchased.</param>
        public void CreateOrder(OrderDto orderDto,IShoppingCartBs shoppingCartBs)
        {
            base.Add(orderDto);
            IOrderDetailBs _orderDetailBs = new OrderDetailBs(AppDbContext);
            var shoppingCartItems = shoppingCartBs.ShoppingCartItems;
            foreach(var shoppingCartItem in shoppingCartItems)
            {
                var orderDetailDto = new OrderDetailDto()
                {
                    Amount = shoppingCartItem.Amount,
                    Pie = new PieDto() { Id = shoppingCartItem.Pie.Id },
                    Order = new OrderDto() { Id = orderDto.Id },
                    Price = shoppingCartItem.Pie.Price,
                    Id=Guid.NewGuid()
                };
                _orderDetailBs.Add(orderDetailDto);
            }
        }
    }
}
