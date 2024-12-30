namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class IEnumerableTypeExtensions
    {
        internal static List<string> GetFullNamesOrdered(this IEnumerable<Type> types)
        {
            return types
                .Select(type => type.FullName)
                .OrderBy(name => name, StringComparer.Ordinal)
                .ToList();
        }
    }
}
