namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition HaveName(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveFullName(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveFullName(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameStartingWith(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameStartingWith(names));
            return this;
        }

        public ITypesAssertionPostCondition HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(TypeDefinitionPredicate.HaveNameEndingWith(names));
            return this;
        }
    }
}
