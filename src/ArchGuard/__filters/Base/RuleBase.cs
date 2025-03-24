namespace ArchGuard.Filters.Base;

public abstract class RuleBase<TContext>
    where TContext : class
{
    internal AddPredicateCallback<RuleBase<TContext>, TContext> AddPredicateCallback { get; set; } = null!;
}
