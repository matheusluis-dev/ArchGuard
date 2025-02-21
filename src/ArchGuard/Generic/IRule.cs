namespace ArchGuard.Generic
{
    internal interface IRule<TContext>
        where TContext : class
    {
        RuleCallback<IRule<TContext>> Callback { get; set; }
    }
}
