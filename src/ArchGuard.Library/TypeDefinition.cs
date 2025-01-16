namespace ArchGuard.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Cached;
    using Microsoft.CodeAnalysis;

    public sealed class TypeDefinition : IEquatable<TypeDefinition>
    {
        public Project Project { get; init; }
        public INamedTypeSymbol Symbol { get; init; }

        internal TypeDefinition(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            Symbol = symbol;
        }

        internal Compilation? GetCompilation()
        {
            return Project?.GetCompilationAsync().Result;
        }

        internal IEnumerable<TypeDefinition> GetAllTypesFromProject()
        {
            var compilation = GetCompilation();

            return TypesSearchCached
                .GetAllTypeMembers(compilation!.GlobalNamespace, compilation!.Assembly)
                .Select(type => new TypeDefinition(Project, type));
        }

        public override int GetHashCode()
        {
            return new { Project, Symbol }.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TypeDefinition t)
                return false;

            return Equals(t);
        }

        public bool Equals(TypeDefinition? other)
        {
            return Project.Equals(other?.Project)
                && Symbol.Equals(other?.Symbol, SymbolEqualityComparer.Default);
        }
    }
}
