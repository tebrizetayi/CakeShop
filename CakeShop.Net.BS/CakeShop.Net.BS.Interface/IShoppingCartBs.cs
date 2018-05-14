using CakeShop.Net.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Interface
{
    public interface IShoppingCartBs : IBaseBs<ShoppingCartItemDto>
    {
        IEnumerable<ShoppingCartItemDto> GetShoppingCartItems();
        Guid ShoppingCartId { get; set; }
        IEnumerable<ShoppingCartItemDto> ShoppingCartItems { get; set; }
        decimal GetShoppingCartTotal();
        void AddToCart(PieDto pie, int amount);
        int RemoveFromCart(PieDto pie);
        void ClearCart();
    }
}
