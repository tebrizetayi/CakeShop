using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeShop.Net.BS.Implementation
{
    public class ShoppingCartBs:BaseBs<ShoppingCartItemDto, ShoppingCartItem>,IShoppingCartBs
    {
        public  ShoppingCartBs(AppDbContext appDbContext):base(appDbContext)
        {
            _shoppingCartItemBs = new ShoppingCartItemBs(AppDbContext);
        }

        private IShoppingCartItemBs _shoppingCartItemBs;

        public Guid ShoppingCartId { get; set; }

        public IEnumerable<ShoppingCartItemDto> ShoppingCartItems { get; set; }

        /// <summary>
        /// Gets the current shopping cart.
        /// </summary>
        /// <param name="services"></param>
        /// <returns>Returns the shopping cart.</returns>
        public static ShoppingCartBs GetCart(IServiceProvider services)
        {
            ISession session = null;
            AppDbContext context = null ;
            if (services != null)
            {
                context = (AppDbContext)services.GetService(typeof(AppDbContext));
                var httpContextAccessor = ((IHttpContextAccessor)services.GetRequiredService(typeof(IHttpContextAccessor)));
                if (httpContextAccessor != null)
                {
                    session = httpContextAccessor.HttpContext.Session;
                }
            }

            Guid cartId = session?.GetString("ShoppingCartId") != null ?
                                new Guid(session.GetString("ShoppingCartId")) : Guid.NewGuid();
            session.SetString("ShoppingCartId", cartId.ToString());

            var lstShoppingCartItemDto = new ShoppingCartItemBs(context).
                                        FindBy(c => c.ShoppingCart.Id == cartId && c.Status == true);

            return new ShoppingCartBs(context)
            {
                ShoppingCartId = cartId,
                ShoppingCartItems = lstShoppingCartItemDto
            };
        }

        /// <summary>
        /// Pie Data transfer object that should be added into the shopping cart.
        /// </summary>
        /// <param name="pie"></param>
        /// <param name="amount"></param>
        public void AddToCart(PieDto pie, int amount)
        {
            var pieId = pie.Id;
            var shoppingCartId = ShoppingCartId;
            var shoppingCartItem = _shoppingCartItemBs
                .FindBy(x => x.Pie.Id == pieId && x.ShoppingCart.Id == shoppingCartId && x.Status==true)
                .FirstOrDefault();

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItemDto
                {
                    ShoppingCart = new ShoppingCartDto() { Id = shoppingCartId },
                    Pie = new PieDto() { Id = pieId },
                    Amount = 1,
                    Id = Guid.NewGuid(),

                };
                _shoppingCartItemBs.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
                _shoppingCartItemBs.Edit(shoppingCartItem);
            }
        }

        /// <summary>
        /// Pie Data transfer object that should be removed from the shopping cart.
        /// </summary>
        /// <param name="pie">Pie that should be removed.</param>
        public int RemoveFromCart(PieDto pie)
        {
            var shoppingCartItem = _shoppingCartItemBs.FindBy(x => x.Pie.Id == pie.Id && x.ShoppingCart.Id == ShoppingCartId).FirstOrDefault();

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                    _shoppingCartItemBs.Edit(shoppingCartItem);
                }
                else
                {
                    _shoppingCartItemBs.Delete(shoppingCartItem);
                }
            }

            return localAmount;
        }

        /// <summary>
        /// Gets the list of items in the shopping cart.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShoppingCartItemDto> GetShoppingCartItems()
        {
            var shoppingCartId = ShoppingCartId;
             ShoppingCartItems = _shoppingCartItemBs.FindBy(c => c.ShoppingCart.Id == shoppingCartId && c.Status==true);
            return ShoppingCartItems;
        }

        /// <summary>
        /// Clears the current shopping cart.
        /// </summary>
        public void ClearCart()
        {
            var shoppingCartId = ShoppingCartId;
            var cartItems = _shoppingCartItemBs.FindBy(x => x.ShoppingCart.Id == shoppingCartId && x.Status == true);
            _shoppingCartItemBs.Delete(cartItems);
        }

        /// <summary>
        /// Gets the total price of current shopping cart.
        /// </summary>
        /// <returns>Total price of current shopping cart.</returns>
        public decimal GetShoppingCartTotal()
        {
            var shoppingCartId = ShoppingCartId;
            var total = _shoppingCartItemBs.FindBy(c => c.ShoppingCart.Id == shoppingCartId && c.Status==true).Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
