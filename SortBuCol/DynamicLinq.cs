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
