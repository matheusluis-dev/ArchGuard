namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Collections.Generic;

    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<T> Copy<T>(this IEnumerable<T> enumerable)
        {
            return new List<T>(enumerable);
        }

        internal static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }

            return enumerable;
        }
    }
}
