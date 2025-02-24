namespace ArchGuard.Generic;

public interface IFilterSequence<TRule, TContext>
    where TRule : class, IRule<TContext>
    where TContext : class
{
    public TRule And { get; }
    public TRule Or { get; }
}
