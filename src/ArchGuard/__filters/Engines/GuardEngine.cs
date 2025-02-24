namespace ArchGuard.Filters.Base;

using ArchGuard.__filters.Engines;
using ArchGuard.Core.Contexts;

public sealed class GuardEngine<TRules, TContext>
    where TRules : RuleBase<TContext>
    where TContext : class
{
    private readonly TRules _filterRules;
    private readonly ContextEngine<TContext> _filterContext;
    private readonly Filter<TRules, TContext> _filter;

    internal GuardEngine(TRules filterRules, ContextEngine<TContext> filterContext)
    {
        _filterRules = filterRules;
        _filterRules.SequenceCallback = AddFilterPredicate;
        _filterContext = filterContext;
        _filter = new Filter<TRules, TContext>(FilterRule, FilterOr);
    }

    internal IFilterEntryPoint<TRules> Start()
    {
        return _filter;
    }

    public TRules FilterRule()
    {
        return _filterRules;
    }

    public void FilterOr()
    {
        _filterContext.Or();
    }

    public ISequence<RuleBase<TContext>, TContext> AddFilterPredicate(Func<TContext, StringComparison, bool> predicate)
    {
        _filterContext.AddPredicate(predicate);
        return _filter;
    }
}
