namespace ArchGuard.Generic
{
    internal class FilterTypeRule : IRule
    {
        public RuleCallback<IRule> Callback { get; set; } = null!;

        public IFilterSequence<IRule> Whatever()
        {
            // do something
            return Callback.Invoke();
        }
    }
}
