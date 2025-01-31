namespace ArchGuard
{
    public sealed partial class MethodAssertion
    {
        public IMethodAssertionSequence BeAsynchronous()
        {
            _context.AddPredicate(MethodPredicate.Asynchronous);
            return this;
        }

        public IMethodAssertionSequence NotBeAsynchronous()
        {
            _context.AddPredicate(MethodPredicate.NotAsynchronous);
            return this;
        }

        public IMethodAssertionSequence BeStatic()
        {
            _context.AddPredicate(MethodPredicate.Static);
            return this;
        }

        public IMethodAssertionSequence NotBeStatic()
        {
            _context.AddPredicate(MethodPredicate.NotStatic);
            return this;
        }
    }
}
