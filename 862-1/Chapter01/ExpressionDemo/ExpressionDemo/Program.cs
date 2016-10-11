using System;
using System.Collections.Generic;
using System.Text;
using System.Query;
using System.Expressions;
using System.Xml.XLinq;
using System.Data.DLinq;

namespace ExpressionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Listing 1-5
            Expression<Func<Person, bool>> e = p => p.ID == 1;

            BinaryExpression    body  = (BinaryExpression)e.Body;
            MemberExpression    left  = (MemberExpression)body.Left;
            ConstantExpression    right  = (ConstantExpression)body.Right;

            Console.WriteLine(left.ToString());    
            Console.WriteLine(body.NodeType.ToString());
            Console.WriteLine(right.Value.ToString());
            #endregion
        }
    }
}
