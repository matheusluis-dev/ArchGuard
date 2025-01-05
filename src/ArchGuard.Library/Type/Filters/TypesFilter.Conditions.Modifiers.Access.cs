namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Extensions.Type;
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.ApplyFilter(TypePredicates.Public);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.ApplyFilter(TypePredicates.NotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.ApplyFilter(TypePredicates.Internal);
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.ApplyFilter(TypePredicates.NotInternal);
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.ApplyFilter(TypePredicates.Private);
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.ApplyFilter(TypePredicates.NotPrivate);
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.ApplyFilter(TypePredicates.Protected);
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.ApplyFilter(TypePredicates.NotProtected);
            return this;
        }

#if NET7_0_OR_GREATER
        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.ApplyFilter(TypePredicates.FileScoped);
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.ApplyFilter(TypePredicates.NotFileScoped);
            return this;
        }
#endif
    }
}
