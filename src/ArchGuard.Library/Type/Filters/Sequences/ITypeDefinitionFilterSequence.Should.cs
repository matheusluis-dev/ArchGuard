namespace ArchGuard.Library.Type.Filters
{
    using ArchGuard.Library.Type.Assertions;

    public partial interface ITypeDefinitionFilterSequence
    {
        ITypeDefinitionAssertionRule Should { get; }
    }
}
