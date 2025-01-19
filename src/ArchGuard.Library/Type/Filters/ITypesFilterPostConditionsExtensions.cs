using ArchGuard.Library.Type.Filters;

namespace ArchGuard.Library.Type.Filters
{
    using System;

    public static class ITypesFilterPostConditionsExtensions
    {
        public static ITypesFilterPostConditions And(
            this ITypesFilterPostConditions iTypesFilterPostConditions,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeDefinitionFilters typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeDefinitionFilters)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);

            return typesFilter;
        }

        public static ITypesFilterPostConditions Or(
            this ITypesFilterPostConditions iTypesFilterPostConditions,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeDefinitionFilters typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeDefinitionFilters)}"
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
