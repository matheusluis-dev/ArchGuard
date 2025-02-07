namespace ArchGuard
{
    public static class IPropertyAssertionSequenceExtensions
    {
        public static IPropertyAssertionSequence And(
            this IPropertyAssertionSequence fieldAssertionSequence,
            Func<IPropertyAssertionRule, IPropertyAssertionSequence> filter
        )
        {
            if (!(fieldAssertionSequence is PropertyAssertion fieldAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(fieldAssertionSequence)} must be of type {nameof(PropertyFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(fieldAssertion);

            return fieldAssertion;
        }

        public static IPropertyAssertionSequence Or(
            this IPropertyAssertionSequence fieldAssertionSequence,
            Func<IPropertyAssertionRule, IPropertyAssertionSequence> filter
        )
        {
            if (!(fieldAssertionSequence is PropertyAssertion fieldAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(fieldAssertionSequence)} must be of type {nameof(PropertyFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            fieldAssertion.OrInternal();
            filter(fieldAssertion);

            return fieldAssertion;
        }
    }
}
