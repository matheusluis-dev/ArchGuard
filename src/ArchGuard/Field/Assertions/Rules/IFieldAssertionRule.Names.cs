namespace ArchGuard
{
    public partial interface IFieldAssertionRule
    {
        IFieldAssertionSequence HaveNamePascalCased();

        IFieldAssertionSequence HaveNameCamelCased(char prefix);
        IFieldAssertionSequence HaveNameCamelCased(string prefix);
    }
}
