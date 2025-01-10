namespace ArchGuard.Roslyn.Type.Assertions
{
    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
