namespace ArchGuard.Filters.Base;

using ArchGuard.__filters.Engines;
using ArchGuard.Core.Contexts;

public delegate RuleBase<TFilterContext> RuleCallback<TFilterContext>()
    where TFilterContext : class;

public delegate ISequence<TRules, TFilterContext> SequenceCallback<TRules, TFilterContext>()
    where TRules : RuleBase<TFilterContext>
    where TFilterContext : class;

public delegate ISequence<TRules, TContext> AddPredicateCallback<TRules, TContext>(
    Func<TContext, StringComparison, bool> predicate
)
    where TRules : RuleBase<TContext>
    where TContext : class;

public sealed class FilterMediator<TRules, TContext>
    where TRules : RuleBase<TContext>
    where TContext : class
{
    internal Should<RuleBase<TContext>, TContext> ShouldCallback { get; set; }

    internal ContextEngine<TContext> Context { get; private init; }

    private readonly TRules _rules;
    private readonly Filter<TRules, TContext> _filter;

    internal FilterMediator(TRules rules, ContextEngine<TContext> context)
    {
        _rules = rules;

        Context = context;
        _filter = new Filter<TRules, TContext>(() => _rules, () => _filter!);

        _rules.AddPredicateCallback = (Func<TContext, StringComparison, bool> predicate) =>
        {
            Context.AddPredicate(predicate);
            return (ISequence<RuleBase<TContext>, TContext>)(ISequence<TRules, TContext>)_filter;
        };
    }

    internal IFilterEntryPoint<TRules, TContext> Start()
    {
        return _filter;
    }

    internal RuleBase<TContext> Should => ShouldCallback.Invoke();
}
