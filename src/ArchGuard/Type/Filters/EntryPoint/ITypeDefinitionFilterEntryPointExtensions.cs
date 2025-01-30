namespace ArchGuard
{
    using System;

    public static class ITypeDefinitionFilterEntryPointExtensions
    {
        public static ITypeFilterSequence That(
            this ITypeFilterEntryPoint iTypesFilterStart,
            Func<ITypeFilterRule, ITypeFilterSequence> filter
        )
        {
            if (!(iTypesFilterStart is TypeFilter typesFilter))
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
