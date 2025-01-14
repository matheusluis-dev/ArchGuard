namespace ArchGuard.Library
{
    using Microsoft.CodeAnalysis;

    public sealed class Type_
    {
        public Project Project { get; init; }
        public INamedTypeSymbol Symbol { get; init; }

        public Type_(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            Symbol = symbol;
        }
    }
}
