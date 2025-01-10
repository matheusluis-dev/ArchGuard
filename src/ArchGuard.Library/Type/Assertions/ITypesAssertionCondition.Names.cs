namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypesAssertionCondition
    {
        ITypesAssertionPostCondition HaveName(params string[] names);
        ITypesAssertionPostCondition HaveFullName(params string[] names);
        ITypesAssertionPostCondition HaveNameStartingWith(params string[] names);
        ITypesAssertionPostCondition HaveNameEndingWith(params string[] names);
    }
}
