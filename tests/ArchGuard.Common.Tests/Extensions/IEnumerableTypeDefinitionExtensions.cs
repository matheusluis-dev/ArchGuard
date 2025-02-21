namespace ArchGuard.Tests.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    public static class IEnumerableTypeDefinitionExtensions
    {
        public static IList<string> GetFullNames(this IEnumerable<TypeDefinition> types)
        {
            return types.Select(type => type.FullName).OrderBy(fullName => fullName, StringComparer.Ordinal).ToList();
        }
    }
}
