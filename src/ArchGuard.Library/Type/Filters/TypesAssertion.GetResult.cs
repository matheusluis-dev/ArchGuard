namespace ArchGuard.Library.Type.Filters
{
    using System;
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypesFilter
    {
        public ITypesAssertionCondition And()
        {
            return this;
        }

        public ITypesAssertionPostCondition And(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            filter(this);

            return this;
        }

        public ITypesAssertionCondition Or()
        {
            _context.OrAssertion();
            return this;
        }

        public ITypesAssertionPostCondition Or(
            Func<ITypesAssertionCondition, ITypesAssertionPostCondition> filter
        )
        {
            if (filter is null)
                throw new ArgumentNullException(nameof(filter));

            _context.OrAssertion();
            filter(this);

            return this;
        }

        public TypesAssertionResult GetResult()
        {
            return _context.GetResult();
        }
    }
}
