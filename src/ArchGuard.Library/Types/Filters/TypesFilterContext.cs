namespace ArchGuard.Library.Types.Filters;

public sealed class TypesFilterContext
{
    private readonly IEnumerable<Type> _typesWithoutFilter;

    public IEnumerable<Type> Types { get; private set; }

    private bool AndOperator { get; set; } = true;
    private bool OrOperator { get; set; }

    private List<IEnumerable<Type>> GroupedTypes { get; set; } = [];

    public void And()
    {
        AndOperator = true;
        OrOperator = false;
    }

    public void Or()
    {
        AndOperator = false;
        OrOperator = true;

        GroupTypes();
    }

    private void GroupTypes()
    {
        if (!OrOperator)
            throw new InvalidOperationException();

        GroupedTypes.Add([.. Types]);
    }

    public TypesFilterContext(IEnumerable<Type> types)
    {
        Types = [.. types];
        _typesWithoutFilter = [.. types];
    }

    public void ApplyFilter(Func<Type, bool> filter)
    {
        if (OrOperator)
        {
            var orTypes = _typesWithoutFilter.Where(filter);
            Types = Types.Union(orTypes);

            return;
        }

        if (AndOperator)
            Types = Types.Where(filter);

        foreach (var group in GroupedTypes)
            Types = Types.Union(group);
    }
}
