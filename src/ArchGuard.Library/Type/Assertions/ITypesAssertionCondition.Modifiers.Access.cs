namespace ArchGuard.Library.Type.Assertions
{
    public partial interface ITypesAssertionCondition
    {
        ITypesAssertionPostCondition BePublic();
        ITypesAssertionPostCondition BeNotPublic();

        ITypesAssertionPostCondition BeInternal();
        ITypesAssertionPostCondition BeNotInternal();

        ITypesAssertionPostCondition BePrivate();
        ITypesAssertionPostCondition BeNotPrivate();

        ITypesAssertionPostCondition BeProtected();
        ITypesAssertionPostCondition BeNotProtected();

#if NET7_0_OR_GREATER
        ITypesAssertionPostCondition BeFileScoped();
        ITypesAssertionPostCondition BeNotFileScoped();
#endif
    }
}
