namespace ArchGuard.Library.Types.Filters;

using ArchGuard.Library.Types.Filters.Interfaces;

public sealed partial class TypesFilter
{
    public ITypesFilterPostCondition ArePublic()
    {
        _context.ApplyFilter(type => type.IsPublic);
        return this;
    }

    public ITypesFilterPostCondition AreNotPublic()
    {
        _context.ApplyFilter(type => type.IsNotPublic);
        return this;
    }

    public ITypesFilterPostCondition AreInternal()
    {
        _context.ApplyFilter(type => type.IsInternal());
        return this;
    }

    public ITypesFilterPostCondition AreNotInternal()
    {
        _context.ApplyFilter(type => type.IsNotInternal());
        return this;
    }

    public ITypesFilterPostCondition ArePrivate()
    {
        _context.ApplyFilter(type => type.IsPrivate());
        return this;
    }

    public ITypesFilterPostCondition AreNotPrivate()
    {
        _context.ApplyFilter(type => type.IsNotPrivate());
        return this;
    }

    // TODO move to a proper location
    public ITypesFilterPostCondition AreNested()
    {
        _context.ApplyFilter(type => type.IsNested);
        return this;
    }

    // TODO move to a proper location
    public ITypesFilterPostCondition AreNotNested()
    {
        _context.ApplyFilter(type => !type.IsNested);
        return this;
    }

    public ITypesFilterPostCondition ArePartial()
    {
        _context.ApplyFilter(type => type.IsPartial());
        return this;
    }

    public ITypesFilterPostCondition AreNotPartial()
    {
        _context.ApplyFilter(type => type.IsNotPartial());
        return this;
    }

    public ITypesFilterPostCondition AreSealed()
    {
        _context.ApplyFilter(type => type.IsSealed());
        return this;
    }

    public ITypesFilterPostCondition AreNotSealed()
    {
        _context.ApplyFilter(type => type.IsNotSealed());
        return this;
    }
}
