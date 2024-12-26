namespace ArchGuard.Library.Types.Filter;

public sealed partial class TypesFilter
{
    public ITypesFilterPostCondition AreClasses()
    {
        _context.ApplyFilter(type => type.IsClass);
        return this;
    }

    public ITypesFilterPostCondition AreNotClasses()
    {
        _context.ApplyFilter(type => !type.IsClass);
        return this;
    }

    public ITypesFilterPostCondition AreInterfaces()
    {
        _context.ApplyFilter(type => type.IsInterface);
        return this;
    }

    public ITypesFilterPostCondition AreNotInterfaces()
    {
        _context.ApplyFilter(type => !type.IsInterface);
        return this;
    }

    public ITypesFilterPostCondition AreStructs()
    {
        _context.ApplyFilter(type => type.IsStruct());
        return this;
    }

    public ITypesFilterPostCondition AreNotStructs()
    {
        _context.ApplyFilter(type => type.IsNotStruct());
        return this;
    }

    public ITypesFilterPostCondition AreEnums()
    {
        _context.ApplyFilter(type => type.IsEnum);
        return this;
    }

    public ITypesFilterPostCondition AreNotEnums()
    {
        _context.ApplyFilter(type => !type.IsEnum);
        return this;
    }
}
