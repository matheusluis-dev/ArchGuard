namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableTypeExtensions
    {
        public static List<string> GetFullNames(this IEnumerable<Type> types)
        {
            return types
                .Select(type => type.FullNameClean())
                .OrderBy(fullName => fullName, StringComparer.Ordinal)
                .ToList();
        }
    }
}
