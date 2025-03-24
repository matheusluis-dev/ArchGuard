namespace ArchGuard.Filters.Base;

public interface IFilterEntryPoint<TRule, TContext>
    where TRule : RuleBase<TContext>
    where TContext : class
{
    TRule That { get; }
}
