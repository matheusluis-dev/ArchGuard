namespace ArchGuard.__filters.Engines;

using ArchGuard.__filters.Engines.Delegates;
using ArchGuard.Filters.Base;

public sealed class Filter<TRule, TContext> : IFilterEntryPoint<TRule>, ISequence<TRule, TContext>
    where TRule : RuleBase<TContext>
    where TContext : class
{
    private readonly AddRuleCallback<TRule, TContext> _addRule;
    private readonly AddContextOrCallback _contextOr;

    internal Filter(AddRuleCallback<TRule, TContext> addRule, AddContextOrCallback contextOr)
    {
        _addRule = addRule;
        _contextOr = contextOr;
    }

    public TRule That => _addRule.Invoke();

    public TRule And => _addRule.Invoke();

    public TRule Or
    {
        get
        {
            _contextOr.Invoke();
            return _addRule.Invoke();
        }
    }
}
