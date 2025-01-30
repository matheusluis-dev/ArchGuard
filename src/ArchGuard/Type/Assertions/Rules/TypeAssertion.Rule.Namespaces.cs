namespace ArchGuard
{
    public sealed partial class TypeAssertion
    {
        public ITypeAssertionSequence ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name));
            return this;
        }

        public ITypeAssertionSequence ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypeAssertionSequence ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypeAssertionSequence NotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypeAssertionSequence NotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypeAssertionSequence NotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
