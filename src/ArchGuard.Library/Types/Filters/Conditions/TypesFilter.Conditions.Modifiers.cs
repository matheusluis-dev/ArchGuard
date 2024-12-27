namespace ArchGuard.Library.Types.Filters;

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

    // TODO move to a proper location
    public ITypesFilterPostConditions AreNested()
    {
        _context.ApplyFilter(type => type.IsNested);
        return this;
    }

    // TODO move to a proper location
    public ITypesFilterPostConditions AreNotNested()
    {
        _context.ApplyFilter(type => !type.IsNested);
        return this;
    }

    public ITypesFilterPostConditions ArePartial()
    {
        _context.ApplyFilter(type => type.IsPartial());
        return this;
    }

    public ITypesFilterPostConditions AreNotPartial()
    {
        _context.ApplyFilter(type => type.IsNotPartial());
        return this;
    }

    public ITypesFilterPostConditions AreSealed()
    {
        _context.ApplyFilter(type => type.IsSealed());
        return this;
    }

    public ITypesFilterPostConditions AreNotSealed()
    {
        _context.ApplyFilter(type => type.IsNotSealed());
        return this;
    }
}
