namespace ArchGuard.Library.Types.Filter;

public sealed class TypesFilterContext
{
    public IEnumerable<Type> Types { get; private set; }

    public TypesFilterContext(IEnumerable<Type> types)
    {
        Types = types;
    }

    public void ApplyFilter(Func<Type, bool> filter)
    {
        Types = Types.Where(filter);
    }
}
