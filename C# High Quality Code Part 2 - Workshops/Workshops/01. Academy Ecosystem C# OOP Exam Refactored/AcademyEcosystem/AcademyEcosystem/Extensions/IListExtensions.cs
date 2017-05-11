using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    public static class IListExtensions
    {
        public static void RemoveAll<T>(this IList<T> items, Func<T, bool> predicate)
        {
            for (int index = 0; index < items.Count; index++)
            {
                if (predicate(items[index]))
                {
                    items.RemoveAt(index);
                    index--;
                }
            }
        }
    }
}
