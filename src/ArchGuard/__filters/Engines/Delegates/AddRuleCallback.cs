namespace ArchGuard.__filters.Engines.Delegates;

using ArchGuard.Filters.Base;

public delegate TRule AddRuleCallback<TRule, TContext>()
    where TRule : RuleBase<TContext>
    where TContext : class;
