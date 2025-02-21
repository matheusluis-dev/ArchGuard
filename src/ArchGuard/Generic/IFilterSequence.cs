namespace ArchGuard.Generic
{
    internal interface IFilterSequence<TRule>
        where TRule : class, IRule
    {
        public TRule And { get; }
        public TRule Or { get; }
    }
}
