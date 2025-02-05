namespace ArchGuard.Core.Field.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{SymbolName} | Type: {Type.SymbolFullName}")]
    public sealed class FieldDefinition : IEquatable<FieldDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public TypeDefinition Type { get; init; }

        public IFieldSymbol Symbol { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string SymbolName { get; init; }

        internal FieldDefinition(TypeDefinition type, IFieldSymbol symbol)
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

        public bool Equals(FieldDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && SymbolName.Equals(other?.SymbolName, StringComparison.Ordinal);
        }
    }
}
