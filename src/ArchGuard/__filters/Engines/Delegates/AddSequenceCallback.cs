namespace ArchGuard.__filters.Engines.Delegates;

using ArchGuard.Filters.Base;

public delegate ISequence<TFilterRule, TContext> AddSequenceCallback<TFilterRule, TContext>(
    Func<TContext, StringComparison, bool> predicate
)
    where TFilterRule : RuleBase<TContext>
    where TContext : class;
