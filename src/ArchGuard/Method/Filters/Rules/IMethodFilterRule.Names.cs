namespace ArchGuard
{
    public partial interface IMethodFilterRule
    {
        IMethodFilterSequence HaveNameEndingWith(params string[] names);
        IMethodFilterSequence NotHaveNameEndingWith(params string[] names);
    }
}
