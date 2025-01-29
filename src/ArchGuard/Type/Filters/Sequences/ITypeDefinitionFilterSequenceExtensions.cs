using ArchGuardType.Filters;

namespace ArchGuard.Type.Filters.Sequences
{
    using System;

    public static class ITypeDefinitionFilterSequenceExtensions
    {
        public static ITypeDefinitionFilterSequence And(
            this ITypeDefinitionFilterSequence iTypesFilterPostConditions,
            Func<ITypeDefinitionFilterRule, ITypeDefinitionFilterSequence> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeDefinitionFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeDefinitionFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);

            return typesFilter;
        }

        public static ITypeDefinitionFilterSequence Or(
            this ITypeDefinitionFilterSequence iTypesFilterPostConditions,
            Func<ITypeDefinitionFilterRule, ITypeDefinitionFilterSequence> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeDefinitionFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeDefinitionFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            typesFilter.OrInternal();
            filter(typesFilter);

            return typesFilter;
        }
    }
}
