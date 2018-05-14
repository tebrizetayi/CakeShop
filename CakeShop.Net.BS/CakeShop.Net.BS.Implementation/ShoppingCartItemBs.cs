using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Implementation
{
    public class ShoppingCartItemBs : BaseBs<ShoppingCartItemDto, ShoppingCartItem>,IShoppingCartItemBs
    {
        public ShoppingCartItemBs(AppDbContext iDbConnection):base(iDbConnection)
        {
        }
    }
}
