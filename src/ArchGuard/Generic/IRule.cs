namespace ArchGuard.Generic;

public interface IRule<TContext>
    where TContext : class
{
    AddSequenceCallback<IRule<TContext>, TContext> AddSequenceCallback { get; set; }
}
