namespace ArchGuard
{
    using System;

    public static class IFieldFilterSequenceExtensions
    {
        public static IFieldFilterSequence And(
            this IFieldFilterSequence fieldFilterSequence,
            Func<IFieldFilterRule, IFieldFilterSequence> filter
        )
        {
            if (!(fieldFilterSequence is FieldFilter fieldFilter))
            {
                throw new ArgumentException($"{nameof(fieldFilterSequence)} must be of type {nameof(FieldFilter)}");
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(fieldFilter);

            return fieldFilter;
        }

        public static IFieldFilterSequence Or(
            this IFieldFilterSequence fieldFilterSequence,
            Func<IFieldFilterRule, IFieldFilterSequence> filter
        )
        {
            if (!(fieldFilterSequence is FieldFilter typesFilter))
            {
                throw new ArgumentException($"{nameof(fieldFilterSequence)} must be of type {nameof(FieldFilter)}");
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            typesFilter.OrInternal();
            filter(typesFilter);

            return typesFilter;
        }
    }
}
