using System;
using System.Collections.Generic;
using System.Text;

namespace CakeShop.Net.BS.Interface
{
    public interface IUnitOfWork
    {
        IPieBs PieBs { get; set; }
        IShoppingCartBs ShoppingCartBs { get;  }
        IOrderBs OrderBs { get; }
        void SetShoppingCart(IShoppingCartBs shoppingCartBs);
        void Commit();
        void Dispose();
        void RejectChanges();
    }
    
}
