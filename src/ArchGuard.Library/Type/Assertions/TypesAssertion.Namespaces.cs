namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesAssertion
    {
        public ITypesAssertionPostCondition ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypesAssertionPostCondition NotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypeDefinitionPredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
