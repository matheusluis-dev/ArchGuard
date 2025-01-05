namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Filters.Conditions.Interfaces;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public static class ITypesFilterStartExtensions
    {
        public static ITypesFilterPostConditions That(
            this ITypesFilterStart iTypesFilterStart,
            Func<ITypesFilterConditions, ITypesFilterPostConditions> filter
        )
        {
            if (!(iTypesFilterStart is TypesFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterStart)} must be of type {nameof(TypesFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);
            return typesFilter;
        }
    }
}
