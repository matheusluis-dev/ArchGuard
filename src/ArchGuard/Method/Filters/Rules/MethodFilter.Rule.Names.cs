namespace ArchGuard
{
    public sealed partial class MethodFilter
    {
        public IMethodFilterSequence HaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(MethodPredicate.HaveNameEndingWith(names));
            return this;
        }

        public IMethodFilterSequence NotHaveNameEndingWith(params string[] names)
        {
            _context.AddPredicate(MethodPredicate.NotHaveNameEndingWith(names));
            return this;
        }
    }
}
