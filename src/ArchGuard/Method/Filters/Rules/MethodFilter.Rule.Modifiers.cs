namespace ArchGuard
{
    public sealed partial class MethodFilter
    {
        public IMethodFilterSequence AreAsynchronous()
        {
            _context.AddPredicate(MethodPredicate.Asynchronous);
            return this;
        }

        public IMethodFilterSequence AreNotAsynchronous()
        {
            _context.AddPredicate(MethodPredicate.NotAsynchronous);
            return this;
        }
    }
}
