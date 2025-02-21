namespace ArchGuard.Generic
{
    internal delegate IFilterSequence<TRule> RuleCallback<TRule>() where TRule : class, IRule
       ;
}
