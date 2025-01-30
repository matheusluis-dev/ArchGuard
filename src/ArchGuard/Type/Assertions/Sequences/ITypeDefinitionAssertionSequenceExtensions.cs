namespace ArchGuard
{
    using System;

    public static class ITypeDefinitionAssertionSequenceExtensions
    {
        public static ITypeDefinitionAssertionSequence And(
            this ITypeDefinitionAssertionSequence iTypesAssertionPostCondition,
            Func<ITypeDefinitionAssertionRule, ITypeDefinitionAssertionSequence> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypeDefinitionAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypeDefinitionAssertion)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesAssertion);

            return typesAssertion;
        }

        public static ITypeDefinitionAssertionSequence Or(
            this ITypeDefinitionAssertionSequence iTypesAssertionPostCondition,
            Func<ITypeDefinitionAssertionRule, ITypeDefinitionAssertionSequence> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypeDefinitionAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypeDefinitionAssertion)}"
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
