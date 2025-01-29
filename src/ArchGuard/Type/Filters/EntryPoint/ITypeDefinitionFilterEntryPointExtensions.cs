using ArchGuardType.Filters;

namespace ArchGuard.Type.Filters.EntryPoint
{
    using System;

    public static class ITypeDefinitionFilterEntryPointExtensions
    {
        public static ITypeDefinitionFilterSequence That(
            this ITypeDefinitionFilterEntryPoint iTypesFilterStart,
            Func<ITypeDefinitionFilterRule, ITypeDefinitionFilterSequence> filter
        )
        {
            if (!(iTypesFilterStart is TypeDefinitionFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterStart)} must be of type {nameof(TypeDefinitionFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);
            return typesFilter;
        }
    }
}
