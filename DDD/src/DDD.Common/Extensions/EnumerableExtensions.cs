using System.Collections.Generic;

namespace DDD.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T>  ForEach<T>(this IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                yield return item;
            }
        }
    }
}