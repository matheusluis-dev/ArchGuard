namespace ArchGuard.Library.Type.Assertions
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

#if NET7_0_OR_GREATER
        ITypesAssertionPostCondition BeFileScoped();
        ITypesAssertionPostCondition NotBeFileScoped();
#endif
    }
}
