namespace ArchGuard.Library.Type.Assertions
{
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypesAssertionCondition
    {
        ITypesAssertionPostCondition ResideInNamespace(params string[] name);
        ITypesAssertionPostCondition NotResideInNamespace(params string[] name);

        ITypesAssertionPostCondition ResideInNamespaceContaining(params string[] name);
        ITypesAssertionPostCondition NotResideInNamespaceContaining(params string[] name);

        ITypesAssertionPostCondition ResideInNamespaceEndingWith(params string[] name);
        ITypesAssertionPostCondition NotResideInNamespaceEndingWith(params string[] name);
    }
}
