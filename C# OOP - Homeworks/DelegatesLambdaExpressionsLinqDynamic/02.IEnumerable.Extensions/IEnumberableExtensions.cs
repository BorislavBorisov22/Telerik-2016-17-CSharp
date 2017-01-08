namespace IEnumerable.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumberableExtensions
    {
        public static decimal Sum<T>(this IEnumerable<T> collection)
        {
            CheckCollection(collection);

            decimal sum = 0;

            foreach (var element in collection)
            {
                sum += Convert.ToDecimal(element);
            }

            return sum;
        }

        public static decimal Product<T>(this IEnumerable<T> collection)
        {
            CheckCollection(collection);

            decimal product = 1;

            foreach (var element in collection)
            {
                product *= Convert.ToDecimal(element);
            }

            return product;
        }

        public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
        {
            CheckCollection(collection);

            T min = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(min) < 0)
                {
                    min = element;
                }
            }

            return min;
        }

        public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
        {
            CheckCollection(collection);

            T max = collection.First();

            foreach (var element in collection)
            {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;
        }

        public static decimal Average<T>(this IEnumerable<T> collection)
        {
            return collection.Sum() / collection.Count();
        }

        private static void CheckCollection<T>(IEnumerable<T> collection)
        {
            if (collection.Count() <= 0)
            {
                throw new ArgumentException("Collection must not be empty");
            }
        }
    }
}
