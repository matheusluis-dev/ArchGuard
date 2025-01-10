namespace ArchGuard.Roslyn.Type.Assertions
{
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

        public ITypesAssertionCondition And => this;

        public ITypesAssertionCondition Or => OrInternal();

        internal ITypesAssertionCondition OrInternal()
        {
            _context.Or();
            return this;
        }
    }
}
