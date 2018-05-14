using CakeShop.Net.BS.Interface;
using CakeShop.Net.Model.DM;
using CakeShop.Net.Model.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CakeShop.Net.BS.Implementation
{
    /// <summary>
    /// A Unit of Work keeps track of everything you do during a business transaction 
    /// that can affect the database. When you're done, it figures out everything 
    /// that needs to be done to alter the database as a 
    /// result of your work.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _appDbContext;
        
        #region Repositories
        private IPieBs _pieBs;
        private IShoppingCartBs _shoppingCartBs;
        private IOrderBs _orderBs;

        public IPieBs PieBs
        {
            get
            {
                if (_pieBs == null)
                {
                    _pieBs = new PieBs(_appDbContext);
                }
                return _pieBs;
            }
            set
            {
                _pieBs = value;
            }
        }
        public IShoppingCartBs ShoppingCartBs
        {
            get
            {
                return _shoppingCartBs;
            }
        }
        public IOrderBs OrderBs
        {
            get
            {
                if (_orderBs == null)
                {
                    _orderBs = new OrderBs(_appDbContext);
                }
                return _orderBs;
            }
        }
        public void SetShoppingCart(IShoppingCartBs shoppingCartBs)
        {
            _shoppingCartBs = shoppingCartBs;
        }
        #endregion

        public UnitOfWork(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }
        public void Dispose()
        {
            _appDbContext.Dispose();
        }
        public void RejectChanges()
        {
            if (_appDbContext?.ChangeTracker?.Entries() != null)
                foreach (var entry in _appDbContext.ChangeTracker.Entries()
                      .Where(e => e.State != EntityState.Unchanged))
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.State = EntityState.Detached;
                            break;
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            entry.Reload();
                            break;
                    }
                }
        }
    }
}
