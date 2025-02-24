namespace ArchGuard.Generic;

using ArchGuard.Core.Contexts;

public sealed class FilterEngine<TRule, TContext>
    where TRule : class, IRule<TContext>
    where TContext : class
{
    private readonly TRule _rule;
    private readonly ContextEngine<TContext> _context;
    private readonly Filter<TRule, TContext> _filter;

    internal FilterEngine(TRule rule, ContextEngine<TContext> context)
    {
        _rule = rule;
        _rule.AddSequenceCallback = AddSequence;

        _context = context;

        _filter = new Filter<TRule, TContext>(AddRule, AddContextOr);
    }

    public IFilterEntryPoint<TRule> Start()
    {
        return _filter;
    }

    public TRule AddRule()
    {
        return _rule;
    }

    public IFilterSequence<IRule<TContext>, TContext> AddSequence(Func<TContext, StringComparison, bool> predicate)
    {
        _context.AddPredicate(predicate);
        return (IFilterSequence<IRule<TContext>, TContext>)_filter;
    }

    public void AddContextOr()
    {
        _context.Or();
    }
}
