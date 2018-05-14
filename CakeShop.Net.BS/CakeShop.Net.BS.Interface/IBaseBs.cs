using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CakeShop.Net.BS.Interface
{
    public interface IBaseBs<T>
    {
        void Add(T baseDt);
        void Add(IEnumerable<T> lstBaseDt);
        T Delete(T baseDt);
        T Delete(Guid id);
        void Delete(IEnumerable<T> lstBaseDt);
        void Delete(IEnumerable<Guid> lstId);
        void Edit(T baseDt);
        T GetById(Guid id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicateDt);
        IEnumerable<T> GetAll();
    }
}
