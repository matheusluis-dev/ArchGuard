namespace ArchGuard
{
    using System;

    public static class IMethodFilterEntryPointExtensions
    {
        public static IMethodFilterSequence That(
            this IMethodFilterEntryPoint iTypesFilterStart,
            Func<IMethodFilterRule, IMethodFilterSequence> filter
        )
        {
            if (!(iTypesFilterStart is MethodFilter typesFilter))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesFilterStart)} must be of type {nameof(TypeFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesFilter);
            return typesFilter;
        }
    }
}
