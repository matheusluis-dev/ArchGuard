namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Type;
    using Microsoft.CodeAnalysis;

    public static class IEnumerableTypeDefinitionExtensions
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
