namespace ArchGuard
{
    using ArchGuard;

    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence ResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespace(name));
            return this;
        }

        public ITypeFilterSequence ResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceContaining(name));
            return this;
        }

        public ITypeFilterSequence ResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.ResideInNamespaceEndingWith(name));
            return this;
        }

        public ITypeFilterSequence DoNotResideInNamespace(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespace(name));
            return this;
        }

        public ITypeFilterSequence DoNotResideInNamespaceContaining(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceContaining(name));
            return this;
        }

        public ITypeFilterSequence DoNotResideInNamespaceEndingWith(params string[] name)
        {
            _context.AddPredicate(TypePredicate.DoNotResideInNamespaceEndingWith(name));
            return this;
        }
    }
}
