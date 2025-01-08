namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeSpecPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
