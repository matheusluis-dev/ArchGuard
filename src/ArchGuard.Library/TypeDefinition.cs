namespace ArchGuard.Library
{
    using Microsoft.CodeAnalysis;

    public sealed class TypeDefinition
    {
        public Project Project { get; init; }
        public INamedTypeSymbol Symbol { get; init; }

        public TypeDefinition(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            Symbol = symbol;
        }
    }
}
