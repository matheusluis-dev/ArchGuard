namespace ArchGuard
{
    public static class IMethodAssertionSequenceExtensions
    {
        public static IMethodAssertionSequence And(
            this IMethodAssertionSequence methodAssertionSequence,
            Func<IMethodAssertionRule, IMethodAssertionSequence> filter
        )
        {
            if (!(methodAssertionSequence is MethodAssertion methodAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(methodAssertionSequence)} must be of type {nameof(MethodFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(methodAssertion);

            return methodAssertion;
        }

        public static IMethodAssertionSequence Or(
            this IMethodAssertionSequence methodAssertionSequence,
            Func<IMethodAssertionRule, IMethodAssertionSequence> filter
        )
        {
            if (!(methodAssertionSequence is MethodAssertion methodAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(methodAssertionSequence)} must be of type {nameof(MethodFilter)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            methodAssertion.OrInternal();
            filter(methodAssertion);

            return methodAssertion;
        }
    }
}
