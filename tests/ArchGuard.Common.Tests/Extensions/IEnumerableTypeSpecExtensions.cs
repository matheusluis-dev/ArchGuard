namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library;

    public static class IEnumerableTypeSpecExtensions
    {
        public static IList<string> GetFullNames(this IEnumerable<TypeSpec> types)
        {
            return types
                .Select(type => type.FullName)
                .OrderBy(fullName => fullName, StringComparer.Ordinal)
                .ToList();
        }
    }
}
