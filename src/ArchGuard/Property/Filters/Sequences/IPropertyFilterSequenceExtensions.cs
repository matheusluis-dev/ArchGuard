namespace ArchGuard
{
    using System;

    public static class IPropertyFilterSequenceExtensions
    {
        public static IPropertyFilterSequence And(
            this IPropertyFilterSequence propertyFilterSequence,
            Func<IPropertyFilterRule, IPropertyFilterSequence> filter
        )
        {
            if (!(propertyFilterSequence is PropertyFilter propertyFilter))
            {
                throw new ArgumentException(
                    $"{nameof(propertyFilterSequence)} must be of type {nameof(PropertyFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(propertyFilter);

            return propertyFilter;
        }

        public static IPropertyFilterSequence Or(
            this IPropertyFilterSequence propertyFilterSequence,
            Func<IPropertyFilterRule, IPropertyFilterSequence> filter
        )
        {
            if (!(propertyFilterSequence is PropertyFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(propertyFilterSequence)} must be of type {nameof(PropertyFilter)}"
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
