namespace ArchGuard
{
    public sealed partial class MethodAssertion
    {
        public IMethodAssertionSequence HaveNamePascalCased()
        {
            _context.AddPredicate(MethodPredicate.HaveNamePascalCased);
            return this;
        }
    }
}
