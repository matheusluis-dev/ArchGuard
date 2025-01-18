namespace ArchGuard.Library
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using ArchGuard.Library.Cached;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{SymbolFullName}")]
    public sealed class TypeDefinition : IEquatable<TypeDefinition>
    {
        internal string SymbolName => Symbol.GetName();
        internal string SymbolFullName => Symbol.GetFullName();

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
            var symbolFullName = Symbol.GetFullName();

            return new { Project.Name, symbolFullName }.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TypeDefinition t)
                return false;

            return Equals(t);
        }

        public bool Equals(TypeDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Symbol
                    .GetFullName()
                    .Equals(other?.Symbol.GetFullName(), StringComparison.Ordinal);
        }
    }
}
