namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class IEnumerableTypeExtensions
    {
        internal static List<string> GetNames(this IEnumerable<Type> types)
        {
            return types
                .Select(type => type.FullNameClean())
                .OrderBy(fullName => fullName, StringComparer.Ordinal)
                .ToList();
        }
    }
}
