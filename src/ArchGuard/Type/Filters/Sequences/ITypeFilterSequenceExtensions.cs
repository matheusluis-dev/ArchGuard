namespace ArchGuard
{
    using System;

    public static class ITypeFilterSequenceExtensions
    {
        public static ITypeFilterSequence And(
            this ITypeFilterSequence iTypesFilterPostConditions,
            Func<ITypeFilterRule, ITypeFilterSequence> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);

            return typesFilter;
        }

        public static ITypeFilterSequence Or(
            this ITypeFilterSequence iTypesFilterPostConditions,
            Func<ITypeFilterRule, ITypeFilterSequence> filter
        )
        {
            if (!(iTypesFilterPostConditions is TypeFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterPostConditions)} must be of type {nameof(TypeFilter)}"
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
