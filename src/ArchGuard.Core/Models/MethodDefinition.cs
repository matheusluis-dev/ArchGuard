namespace ArchGuard.Core.Models
{
    using System;
    using System.Diagnostics;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{SymbolName} | Type: {Type.SymbolFullName}")]
    public sealed class MethodDefinition : IEquatable<MethodDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public TypeDefinition Type { get; init; }

        public IMethodSymbol Symbol { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string SymbolName { get; init; }

        internal MethodDefinition(TypeDefinition type, IMethodSymbol symbol)
        {
            Project = type.Project;
            Type = type;

            Symbol = symbol;
            SymbolName = Symbol.Name;
        }

        internal Compilation? GetCompilation()
        {
            return Project?.GetCompilationAsync().Result;
        }

        public override int GetHashCode()
        {
            return new { Project.Name, SymbolName }.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TypeDefinition t)
                return false;

            return Equals(t);
        }

        public bool Equals(MethodDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && SymbolName.Equals(other?.SymbolName, StringComparison.Ordinal);
        }
    }
}
