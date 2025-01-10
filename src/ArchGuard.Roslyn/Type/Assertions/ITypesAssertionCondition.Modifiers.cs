namespace ArchGuard.Roslyn.Type.Assertions
{
    public partial interface ITypesAssertionCondition
    {
        ITypesAssertionPostCondition BePartial();
        ITypesAssertionPostCondition NotBePartial();

        ITypesAssertionPostCondition BeSealed();
        ITypesAssertionPostCondition NotBeSealed();

        ITypesAssertionPostCondition BeNested();
        ITypesAssertionPostCondition NotBeNested();

        ITypesAssertionPostCondition BeStatic();
        ITypesAssertionPostCondition NotBeStatic();
    }
}
