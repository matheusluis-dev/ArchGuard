namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Predicates;

    public sealed partial class TypeDefinitionFilters
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Public);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Internal);
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotInternal);
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Private);
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotPrivate);
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.Protected);
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotProtected);
            return this;
        }

        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.FileScoped);
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.AddPredicate(TypeDefinitionPredicate.NotFileScoped);
            return this;
        }
    }
}
