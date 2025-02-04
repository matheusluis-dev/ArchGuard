namespace ArchGuard
{
    public sealed partial class TypeFilter
    {
        public ITypeFilterSequence ArePartial()
        {
            _context.AddPredicate(TypePredicate.Partial);
            return this;
        }

        public ITypeFilterSequence AreNotPartial()
        {
            _context.AddPredicate(TypePredicate.NotPartial);
            return this;
        }

        public ITypeFilterSequence AreSealed()
        {
            _context.AddPredicate(TypePredicate.Sealed);
            return this;
        }

        public ITypeFilterSequence AreNotSealed()
        {
            _context.AddPredicate(TypePredicate.NotSealed);
            return this;
        }

        public ITypeFilterSequence AreNested()
        {
            _context.AddPredicate(TypePredicate.Nested);
            return this;
        }

        public ITypeFilterSequence AreNotNested()
        {
            _context.AddPredicate(TypePredicate.NotNested);
            return this;
        }

        public ITypeFilterSequence AreStatic()
        {
            _context.AddPredicate(TypePredicate.Static);
            return this;
        }

        public ITypeFilterSequence AreNotStatic()
        {
            _context.AddPredicate(TypePredicate.NotStatic);
            return this;
        }

        public ITypeFilterSequence AreAbstract()
        {
            _context.AddPredicate(TypePredicate.Abstract);
            return this;
        }

        public ITypeFilterSequence AreNotAbstract()
        {
            _context.AddPredicate(TypePredicate.NotAbstract);
            return this;
        }
    }
}
