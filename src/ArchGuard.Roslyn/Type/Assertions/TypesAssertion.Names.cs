namespace ArchGuard.Roslyn.Type.Assertions
{
    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition HaveName(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveFullName(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveFullName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveNameStartingWith(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypePredicate.HaveNameEndingWith(names));
            return this;
        }
    }
}
