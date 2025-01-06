namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.ApplyFilter(TypePredicate.Public);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.ApplyFilter(TypePredicate.NotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.ApplyFilter(TypePredicate.Internal);
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.ApplyFilter(TypePredicate.NotInternal);
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.ApplyFilter(TypePredicate.Private);
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.ApplyFilter(TypePredicate.NotPrivate);
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.ApplyFilter(TypePredicate.Protected);
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.ApplyFilter(TypePredicate.NotProtected);
            return this;
        }

#if NET7_0_OR_GREATER
        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.ApplyFilter(TypePredicate.FileScoped);
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.ApplyFilter(TypePredicate.NotFileScoped);
            return this;
        }
#endif
    }
}
