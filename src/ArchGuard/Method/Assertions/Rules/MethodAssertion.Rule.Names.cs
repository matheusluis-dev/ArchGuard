namespace ArchGuard
{
    public sealed partial class MethodAssertion
    {
        public IMethodAssertionSequence HaveNamePascalCased()
        {
            _context.AddPredicate(MethodPredicate.HaveNamePascalCased);
            return this;
        }

        public IMethodAssertionSequence HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(MethodPredicate.HaveNameEndingWith(names));
            return this;
        }

        public IMethodAssertionSequence NotHaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(MethodPredicate.NotHaveNameEndingWith(names));
            return this;
        }
    }
}
