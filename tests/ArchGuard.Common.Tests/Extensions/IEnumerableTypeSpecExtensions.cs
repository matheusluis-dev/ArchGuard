namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    public static class IEnumerableTypeSpecExtensions
    {
        public static IList<string> GetFullNames(this IEnumerable<TypeDefinition> types)
        {
            return types
                .Select(type => type.Symbol.GetFullName())
                .OrderBy(fullName => fullName, StringComparer.Ordinal)
                .ToList();
        }
    }
}
