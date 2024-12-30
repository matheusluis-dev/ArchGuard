namespace ArchGuard.Library.Types.Filters
{
    using ArchGuard.Library.Extensions;
    using ArchGuard.Library.Types.Filters.PostConditions.Interfaces;

    public sealed partial class TypesFilter
    {
        public ITypesFilterPostConditions ArePublic()
        {
            _context.ApplyFilter(type => type.IsPublic);
            return this;
        }

        public ITypesFilterPostConditions AreNotPublic()
        {
            _context.ApplyFilter(type => type.IsNotPublic);
            return this;
        }

        public ITypesFilterPostConditions AreInternal()
        {
            _context.ApplyFilter(type => type.IsInternal());
            return this;
        }

        public ITypesFilterPostConditions AreNotInternal()
        {
            _context.ApplyFilter(type => type.IsNotInternal());
            return this;
        }

        public ITypesFilterPostConditions ArePrivate()
        {
            _context.ApplyFilter(type => type.IsPrivate());
            return this;
        }

        public ITypesFilterPostConditions AreNotPrivate()
        {
            _context.ApplyFilter(type => type.IsNotPrivate());
            return this;
        }

        public ITypesFilterPostConditions AreProtected()
        {
            _context.ApplyFilter(type => type.IsProtected());
            return this;
        }

        public ITypesFilterPostConditions AreNotProtected()
        {
            _context.ApplyFilter(type => type.IsNotProtected());
            return this;
        }

        public ITypesFilterPostConditions AreFileScoped()
        {
            _context.ApplyFilter(type => type.IsFileScoped());
            return this;
        }

        public ITypesFilterPostConditions AreNotFileScoped()
        {
            _context.ApplyFilter(type => type.IsNotFileScoped());
            return this;
        }
    }
}
