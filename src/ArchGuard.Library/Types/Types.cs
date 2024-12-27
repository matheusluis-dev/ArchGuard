namespace ArchGuard.Library.Types;

public sealed class Types
{
    private readonly IEnumerable<Type> _types;

    private Types(IEnumerable<Type> types)
    {
        _types = types;
    }

    public static Types FromAssembly(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        return new Types(assembly.GetTypes());
    }

    public IEnumerable<Type> GetTypes()
    {
        return _types;
    }

    public ITypesFilterCondition That()
    {
        return TypesFilter.That(new TypesFilterContext(_types));
    }
}
