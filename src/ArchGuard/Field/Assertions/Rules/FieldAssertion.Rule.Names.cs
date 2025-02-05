namespace ArchGuard
{
    using ArchGuard.Core.Field.Predicates;

    public sealed partial class FieldAssertion
    {
        public IFieldAssertionSequence HaveNamePascalCased()
        {
            _context.AddPredicate(FieldPredicate.HaveNamePascalCased);
            return this;
        }

        public IFieldAssertionSequence HaveNameCamelCased(char prefix)
        {
            _context.AddPredicate(FieldPredicate.HaveNameCamelCased(prefix));
            return this;
        }

        public IFieldAssertionSequence HaveNameCamelCased(string prefix)
        {
            _context.AddPredicate(FieldPredicate.HaveNameCamelCased(prefix));
            return this;
        }
    }
}
