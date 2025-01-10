namespace ArchGuard.Roslyn.Type.Assertions
{
    public partial interface ITypesAssertionCondition
    {
        ITypesAssertionPostCondition BePublic();
        ITypesAssertionPostCondition NotBePublic();

        ITypesAssertionPostCondition BeInternal();
        ITypesAssertionPostCondition NotBeInternal();

        ITypesAssertionPostCondition BePrivate();
        ITypesAssertionPostCondition NotBePrivate();

        ITypesAssertionPostCondition BeProtected();
        ITypesAssertionPostCondition NotBeProtected();

        ITypesAssertionPostCondition BeFileScoped();
        ITypesAssertionPostCondition NotBeFileScoped();
    }
}
