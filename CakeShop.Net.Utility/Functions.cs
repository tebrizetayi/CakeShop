using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net.Http;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace CakeShop.Net.Utility
{
    public static class Functions
    {
        public static Expression<Func<E, T>> CreateNewStatement<E, T>(string[] fields)
            where T : class, new()
            where E : class , new()
        {
            // input parameter "o"
            var xParameter = Expression.Parameter(typeof(E), "o");

            // new statement "new Data()"
            var xNew = Expression.New(typeof(E));

            //new statemtent 
            var xNewDT = Expression.New(typeof(T));

            // create initializers
            var bindings = fields.Select(o => o.Trim())
                .Select(o =>
                {
                    string propName = o != "Id" ? typeof(E).Name + o : o;
                    // property "Field1"
                    var mi = typeof(E).GetProperty(propName);
                    var miDT = typeof(T).GetProperty(o);

                    // original value "o.Field1"
                    var xOriginal = Expression.Property(xParameter, mi);
                    var xOriginalDT = typeof(T).GetProperty(propName);

                    // set value "Field1 = o.Field1"
                    return Expression.Bind(miDT, xOriginal);
                }
            );

            // initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            var xInit = Expression.MemberInit(xNewDT, bindings);

            // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
            return Expression.Lambda<Func<E, T>>(xInit, xParameter);
        }
    }
}
