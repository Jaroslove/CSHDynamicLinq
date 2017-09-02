using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SortBuCol
{
    static class DynamicOrder
    {
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, string propertyName, string typeOfSort)
        {
            ParameterExpression expressino = Expression.Parameter(typeof(T), "people");
            Expression propertyExpression = Expression.Property(expressino, propertyName);
            var rezult = Expression.Lambda(propertyExpression, expressino);

            var lambda = rezult.Compile();

            Type enumType = typeof(Enumerable);
            var methods = enumType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            //var selmethod = methods.Where(m => m.Name == "OrderByDescending" && m.GetParameters().Count() == 2); ThenBy
            var selmethod = methods.Where(m => m.Name == typeOfSort && m.GetParameters().Count() == 2);
            var method = selmethod.First();
            method = method.MakeGenericMethod(typeof(T), propertyExpression.Type);
            var rez = (IEnumerable<T>)method.Invoke(null, new Object[] { source, lambda });
            return rez.MyOrdering("LastName", "").MyOrdering("FirstName", "").MyOrdering("Patronymic", "");
        }
        public static IEnumerable<T> MyOrdering<T>(this IEnumerable<T> source, string propertyName, string typeOfSort)
        {
            ParameterExpression expressino = Expression.Parameter(typeof(T), "people");
            Expression propertyExpression = Expression.Property(expressino, propertyName);
            var rezult = Expression.Lambda(propertyExpression, expressino);

            var lambda = rezult.Compile();

            Type enumType = typeof(Enumerable);
            var methods = enumType.GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            //var selmethod = methods.Where(m => m.Name == "OrderByDescending" && m.GetParameters().Count() == 2); ThenBy
            var selmethod = methods.Where(m => m.Name == "ThenBy" && m.GetParameters().Count() == 2);
            var method = selmethod.First();
            method = method.MakeGenericMethod(typeof(T), propertyExpression.Type);
            var rez = (IEnumerable<T>)method.Invoke(null, new Object[] { source, lambda });
            return rez;
        }
    }
}
