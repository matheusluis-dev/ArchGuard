namespace ArchGuard.Filters.Base;

public static class ISequenceExtensions
{
    private static ISequence<TRule, TContext> LogicalExpression<TRule, TContext>(
        ISequence<TRule, TContext> sequence,
        Func<TRule, ISequence<TRule, TContext>> filter,
        bool or
    )
        where TRule : RuleBase<TContext>
        where TContext : class
    {
        ArgumentNullException.ThrowIfNull(sequence);
        ArgumentNullException.ThrowIfNull(filter);

        var rules = or ? sequence.Or : sequence.And;
        filter(rules);

        return sequence;
    }

    public static ISequence<TRule, TContext> And<TRule, TContext>(
        this ISequence<TRule, TContext> sequence,
        Func<TRule, ISequence<TRule, TContext>> filter
    )
        where TRule : RuleBase<TContext>
        where TContext : class
    {
        return LogicalExpression(sequence, filter, false);
    }

    public static ISequence<TRule, TContext> Or<TRule, TContext>(
        this ISequence<TRule, TContext> sequence,
        Func<TRule, ISequence<TRule, TContext>> filter
    )
        where TRule : RuleBase<TContext>
        where TContext : class
    {
        return LogicalExpression(sequence, filter, true);
    }
}
