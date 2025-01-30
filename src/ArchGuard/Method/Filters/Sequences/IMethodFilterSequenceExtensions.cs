namespace ArchGuard
{
    using System;

    public static class IMethodFilterSequenceExtensions
    {
        public static IMethodFilterSequence And(
            this IMethodFilterSequence methodFilterSequence,
            Func<IMethodFilterRule, IMethodFilterSequence> filter
        )
        {
            if (!(methodFilterSequence is MethodFilter methodFilter))
            {
                throw new ArgumentException(
                    $"{nameof(methodFilterSequence)} must be of type {nameof(MethodFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(methodFilter);

            return methodFilter;
        }

        public static IMethodFilterSequence Or(
            this IMethodFilterSequence methodFilterSequence,
            Func<IMethodFilterRule, IMethodFilterSequence> filter
        )
        {
            if (!(methodFilterSequence is MethodFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(methodFilterSequence)} must be of type {nameof(MethodFilter)}"
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
