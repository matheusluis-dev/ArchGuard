namespace ArchGuard.Filters.Base;

public interface ISequence<TFilterRule, TContext>
    where TFilterRule : RuleBase<TContext>
    where TContext : class
{
    public TFilterRule And { get; }
    public TFilterRule Or { get; }
}
