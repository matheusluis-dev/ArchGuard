namespace ArchGuard
{
    using ArchGuard.Core.Property.Predicates;

    public sealed partial class PropertyAssertion
    {
        public IPropertyAssertionSequence HaveNamePascalCased()
        {
            _context.AddPredicate(PropertyPredicate.HaveNamePascalCased);
            return this;
        }

        public IPropertyAssertionSequence HaveNameCamelCased(char prefix)
        {
            _context.AddPredicate(PropertyPredicate.HaveNameCamelCased(prefix));
            return this;
        }

        public IPropertyAssertionSequence HaveNameCamelCased(string prefix)
        {
            _context.AddPredicate(PropertyPredicate.HaveNameCamelCased(prefix));
            return this;
        }
    }
}
