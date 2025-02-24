namespace ArchGuard.Filters.Base;

public interface IFilterEntryPoint<TRule>
{
    TRule That { get; }
}
