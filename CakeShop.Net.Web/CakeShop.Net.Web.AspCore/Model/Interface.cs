using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Net.Web.AspCore
{
    public interface ITestScope
    {
        Guid id { get; set; }
    }

    public class testScope:ITestScope
    {
        public testScope()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; set; }
    }
}
