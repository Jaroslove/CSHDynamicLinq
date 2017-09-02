using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortBuCol
{
    static class DynamicLinq
    {
        public static IEnumerable<T> SupremeOreder<T>(this IEnumerable<T> source, string property)
        {
            string[] array = GetArray(property);
            switch (array.Length)
            {
                case 2:
                    return source.OrderBy(array[0], array[1]);
                case 4:
                    return source.OrderBy(array[0], array[1]).MyOrdering(array[2], array[3]);
                case 6:
                    return source.OrderBy(array[0], array[1]).MyOrdering(array[2], array[3]).MyOrdering(array[4], array[5]);
                default:
                    return null;
            }
        }
        private static string[] GetArray(string str)
        {
            if(str == null) { throw new ArgumentNullException(); }
            return str.Split(' ');
        }
        private static void Create(string[] araay)
        {
            int count = araay.Length;
            switch (count)
            {
                case 2:

                default:
                    break;
            }
        }
    }
}
