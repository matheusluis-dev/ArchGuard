namespace ArchGuard.Kernel.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using ArchGuard.Cached;
    using ArchGuard.Extensions;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{SymbolFullName} | Project: {Project.Name}")]
    public sealed class TypeDefinition : IEquatable<TypeDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public INamedTypeSymbol Symbol { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string SymbolName { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string SymbolFullName { get; init; }

        internal TypeDefinition(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            Symbol = symbol;
            SymbolName = Symbol.GetName();
            SymbolFullName = Symbol.GetFullName();
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

        internal IEnumerable<IMethodSymbol> GetConstructors()
        {
            return Symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method => method.MethodKind is MethodKind.Constructor);
        }

        internal IEnumerable<MethodDefinition> GetMethods()
        {
            return Symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method =>
                    method.MethodKind is MethodKind.Ordinary && !method.IsImplicitlyDeclared
                )
                .Select(method => new MethodDefinition(this, method));
        }

        internal IEnumerable<IFieldSymbol> GetFields()
        {
            return Symbol.GetMembers().OfType<IFieldSymbol>();
        }

        internal IEnumerable<IFieldSymbol> GetConstants()
        {
            return Symbol.GetMembers().OfType<IFieldSymbol>().Where(field => field.IsConst);
        }

        internal IEnumerable<IPropertySymbol> GetProperties()
        {
            return Symbol.GetMembers().OfType<IPropertySymbol>();
        }

        public override int GetHashCode()
        {
            return new { Project.Name, SymbolFullName }.GetHashCode();
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
