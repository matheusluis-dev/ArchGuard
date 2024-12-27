namespace ArchGuard.Library.Types;

using ArchGuard.Library.Types.Filters.Common.Interfaces;

public sealed class Types
{
    private Types() { }

    public static ITypesFilterStart FromAssembly(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        var types = assembly.GetTypes();
        var context = new TypesFilterContext(types);

        return TypesFilter.Create(context);
    }
}
