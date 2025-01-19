namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions;

    public sealed partial class TypesAssertion
        : ITypesAssertionCondition,
            ITypesAssertionPostCondition
    {
        private readonly TypesAssertionContext _context;

        internal TypesAssertion(TypesAssertionContext context)
        {
            _context = context;
        }

        internal ITypesAssertionCondition Start()
        {
            return this;
        }

        public static ITypesAssertionCondition Create(TypesAssertionContext context)
        {
            return new TypesAssertion(context);
        }

        public ITypesAssertionCondition And => this;

        public ITypesAssertionCondition Or => OrInternal();

        internal ITypesAssertionCondition OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
