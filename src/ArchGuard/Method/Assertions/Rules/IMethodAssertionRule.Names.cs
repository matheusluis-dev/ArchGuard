namespace ArchGuard
{
    public partial interface IMethodAssertionRule
    {
        IMethodAssertionSequence HaveNamePascalCased();

        IMethodAssertionSequence HaveNameEndingWith(params string[] names);
        IMethodAssertionSequence NotHaveNameEndingWith(params string[] names);
    }
}
