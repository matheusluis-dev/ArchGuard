namespace ArchGuard.Library.Type.Assertions
{
    using System;

    public static class ITypesAssertionPostConditionExtensions
    {
        public static ITypesAssertionPostCondition And(
            this ITypesAssertionPostCondition iTypesAssertionPostCondition,
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypesAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypesAssertion)}"
                );
            }

            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(typesAssertion);

            return typesAssertion;
        }

        public static ITypesAssertionPostCondition Or(
            this ITypesAssertionPostCondition iTypesAssertionPostCondition,
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (!(iTypesAssertionPostCondition is TypesAssertion typesAssertion))
            {
                throw new ArgumentException(
                    $"{nameof(iTypesAssertionPostCondition)} must be of type {nameof(TypesAssertion)}"
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
