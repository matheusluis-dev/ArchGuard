namespace ArchGuard.Library.Extensions
{
    using System.Collections.Generic;

    internal static class IEnumerableExtensions
    {
        internal static IEnumerable<T> Copy<T>(this IEnumerable<T> enumerable)
        {
            return new List<T>(enumerable);
        }
    }
}
