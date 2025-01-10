namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Filters.PostConditions.Interfaces;
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.AddPredicate(TypeSpecPredicate.Public);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.AddPredicate(TypeSpecPredicate.Internal);
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.AddPredicate(TypeSpecPredicate.NotInternal);
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.AddPredicate(TypeSpecPredicate.Private);
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.AddPredicate(TypeSpecPredicate.NotPrivate);
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.AddPredicate(TypeSpecPredicate.Protected);
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.AddPredicate(TypeSpecPredicate.NotProtected);
            return this;
        }

        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.AddPredicate(TypeSpecPredicate.FileScoped);
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.AddPredicate(TypeSpecPredicate.NotFileScoped);
            return this;
        }
    }
}
