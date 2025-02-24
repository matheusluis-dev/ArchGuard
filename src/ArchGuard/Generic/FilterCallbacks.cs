namespace ArchGuard.Generic;

public delegate TRule AddRuleCallback<TRule, TContext>()
    where TRule : class, IRule<TContext>
    where TContext : class;

public delegate IFilterSequence<TRule, TContext> AddSequenceCallback<TRule, TContext>(
    Func<TContext, StringComparison, bool> predicate
)
    where TRule : class, IRule<TContext>
    where TContext : class;

public delegate void AddContextOrCallback();
