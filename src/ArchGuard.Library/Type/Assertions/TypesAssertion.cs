namespace ArchGuard.Library.Type.Assertions
{
    using System;

    public sealed partial class TypesAssertion
        : ITypesAssertionCondition,
            ITypesAssertionPostCondition
    {
        private readonly TypesAssertionContext _context;

        private TypesAssertion(TypesAssertionContext context)
        {
            _context = context;
        }

        public static ITypesAssertionCondition Create(TypesAssertionContext context)
        {
            return new TypesAssertion(context);
        }

        public ITypesAssertionCondition And()
        {
            _context.And();
            return this;
        }

        public ITypesAssertionPostCondition And(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.And();
            filter(this);

            return this;
        }

        public ITypesAssertionCondition Or()
        {
            _context.Or();
            return this;
        }

        public ITypesAssertionPostCondition Or(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.Or();
            filter(this);

            return this;
        }
    }
}
