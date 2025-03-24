namespace ArchGuard.__filters.Engines;

using ArchGuard.Filters.Base;

public sealed class Filter<TRules, TContext> : IFilterEntryPoint<TRules, TContext>, ISequence<TRules, TContext>
    where TRules : RuleBase<TContext>
    where TContext : class
{
    private readonly RuleCallback<TContext> _ruleCallback;
    private readonly SequenceCallback<TRules, TContext> _sequenceCallback;

    public Filter(RuleCallback<TContext> ruleCallback, SequenceCallback<TRules, TContext> sequenceCallback)
    {
        _ruleCallback = ruleCallback;
        _sequenceCallback = sequenceCallback;
    }

    public TRules That => (TRules)_ruleCallback.Invoke();

    public TRules And => (TRules)_ruleCallback.Invoke();

    public TRules Or => _sequenceCallback.Invoke().Or;
}
