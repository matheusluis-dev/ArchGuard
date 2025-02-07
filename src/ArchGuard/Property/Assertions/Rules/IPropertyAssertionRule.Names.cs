namespace ArchGuard
{
    public partial interface IPropertyAssertionRule
    {
        IPropertyAssertionSequence HaveNamePascalCased();

        IPropertyAssertionSequence HaveNameCamelCased(char prefix);
        IPropertyAssertionSequence HaveNameCamelCased(string prefix);
    }
}
