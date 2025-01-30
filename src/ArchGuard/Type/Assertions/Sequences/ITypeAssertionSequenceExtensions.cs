namespace ArchGuard
{
    using System;

    public static class ITypeAssertionSequenceExtensions
    {
        public static ITypeAssertionSequence And(
            this ITypeAssertionSequence iTypesAssertionPostCondition,
            Func<ITypeAssertionRule, ITypeAssertionSequence> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypeAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypeAssertion)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesAssertion);

            return typesAssertion;
        }

        public static ITypeAssertionSequence Or(
            this ITypeAssertionSequence iTypesAssertionPostCondition,
            Func<ITypeAssertionRule, ITypeAssertionSequence> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypeAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypeAssertion)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            typesAssertion.OrInternal();
            filter(typesAssertion);

            return typesAssertion;
        }
    }
}
