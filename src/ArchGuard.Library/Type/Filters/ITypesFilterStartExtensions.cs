using ArchGuard.Library.Type.Filters;

namespace ArchGuard.Library.Type.Filters
{
    using System;

    public static class ITypesFilterStartExtensions
    {
        public static ITypesFilterPostConditions That(
            this ITypesFilterStart iTypesFilterStart,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterStart is TypeDefinitionFilters typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterStart)} must be of type {nameof(TypeDefinitionFilters)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);
            return typesFilter;
        }
    }
}
