namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public static class ITypesFilterPostConditionsExtensions
    {
        public static ITypesFilterPostConditions And(
            this ITypesFilterPostConditions iTypesFilterPostConditions,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypesFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypesFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            typesFilter.AndInternal();
            filter(typesFilter);

            return typesFilter;
        }

        public static ITypesFilterPostConditions Or(
            this ITypesFilterPostConditions iTypesFilterPostConditions,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypesFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypesFilter)}"
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
