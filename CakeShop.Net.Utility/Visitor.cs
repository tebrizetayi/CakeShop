using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CakeShop.Net.Utility
{
    /// <summary>
    /// To change an expression tree, 
    /// you must create a copy of an existing expression tree and 
    /// when you create the copy, make the required changes. 
    /// You can use the ExpressionVisitor class to traverse an existing expression 
    /// tree and to copy each node that it visits.
    /// This class used in FindBy method of BaseBs class. 
    /// It converts expression from Data Transfer Object to Domain Model object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="E"></typeparam>
    public class Visitor<T, E> : ExpressionVisitor
    {
        private ParameterExpression _parameter;
        
        public Visitor(ParameterExpression parameter)
        {
            _parameter = parameter;
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return _parameter;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (typeof(T).BaseType == node.Type.BaseType)
            {
                return Visit(node.Expression);
            }

            if (node.Member.MemberType != System.Reflection.MemberTypes.Property)
            {
                return base.VisitMember(node);
            }
            var memberName = MappedMemberName(node);
            var otherMember = typeof(E).GetProperty(memberName);

            var inner = Visit(node.Expression);
            return Expression.Property(inner, otherMember);
        }

        private string MappedMemberName(MemberExpression node)
        {
            var memberName = string.Empty;
            int indexofDT = node.Expression.Type.Name.ToUpper().IndexOf("DTO");
            if (node.Expression.Type.BaseType == typeof(T).BaseType && indexofDT>-1 && node.Expression.Type.Name.Substring(0, indexofDT) != typeof(E).Name)
            {
                var type = node.Expression.Type.Name.Substring(0, indexofDT);
                memberName = string.Format("{0}_{1}Id", typeof(E).Name, type);
            }
            else
                if (node.Member.Name == "Id")
                {
                    memberName = node.Member.Name;
                }
                else
                {
                    memberName = typeof(E).Name + node.Member.Name;
                }
            return memberName;
        }
    }
}
