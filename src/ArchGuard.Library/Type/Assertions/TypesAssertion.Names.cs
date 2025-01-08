namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition HaveName(params string[] names)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveFullName(params string[] names)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveFullName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameStartingWith(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypeSpecPredicate.HaveNameEndingWith(names));
            return this;
        }
    }
}
