namespace ArchGuard.Filters.Base;

using ArchGuard.__filters.Engines.Delegates;

public abstract class RuleBase<TContext>
    where TContext : class
{
    protected internal AddSequenceCallback<RuleBase<TContext>, TContext> SequenceCallback { get; set; } = null!;
}
