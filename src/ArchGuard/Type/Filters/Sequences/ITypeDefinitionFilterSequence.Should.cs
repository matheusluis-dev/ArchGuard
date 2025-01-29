namespace ArchGuardType.Filters
{
    using ArchGuardType.Assertions;

    public partial interface ITypeDefinitionFilterSequence
    {
        ITypeDefinitionAssertionRule Should { get; }
    }
}
