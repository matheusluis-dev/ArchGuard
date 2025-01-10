namespace ArchGuard.Roslyn.Type.Filters
{
    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.AddPredicate(TypePredicate.Public);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.AddPredicate(TypePredicate.NotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.AddPredicate(TypePredicate.Internal);
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.AddPredicate(TypePredicate.NotInternal);
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.AddPredicate(TypePredicate.Private);
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.AddPredicate(TypePredicate.NotPrivate);
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.AddPredicate(TypePredicate.Protected);
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.AddPredicate(TypePredicate.NotProtected);
            return this;
        }

        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.AddPredicate(TypePredicate.FileScoped);
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.AddPredicate(TypePredicate.NotFileScoped);
            return this;
        }
    }
}
