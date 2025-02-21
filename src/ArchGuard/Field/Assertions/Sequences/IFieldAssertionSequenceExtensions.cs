namespace ArchGuard
{
    public static class IFieldAssertionSequenceExtensions
    {
        public static IFieldAssertionSequence And(
            this IFieldAssertionSequence fieldAssertionSequence,
            Func<IFieldAssertionRule, IFieldAssertionSequence> filter
        )
        {
            if (!(fieldAssertionSequence is FieldAssertion fieldAssertion))
            {
                throw new ArgumentException($"{nameof(fieldAssertionSequence)} must be of type {nameof(FieldFilter)}");
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(fieldAssertion);

            return fieldAssertion;
        }

        public static IFieldAssertionSequence Or(
            this IFieldAssertionSequence fieldAssertionSequence,
            Func<IFieldAssertionRule, IFieldAssertionSequence> filter
        )
        {
            if (!(fieldAssertionSequence is FieldAssertion fieldAssertion))
            {
                throw new ArgumentException($"{nameof(fieldAssertionSequence)} must be of type {nameof(FieldFilter)}");
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            fieldAssertion.OrInternal();
            filter(fieldAssertion);

            return fieldAssertion;
        }
    }
}
