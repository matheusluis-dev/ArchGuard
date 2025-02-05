namespace ArchGuard.Core.Field.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} | Type: {Type.SymbolFullName}")]
    public sealed class FieldDefinition : IEquatable<FieldDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public TypeDefinition Type { get; init; }

        public IFieldSymbol Field { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => Field.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(Field);

        internal bool IsInternal => SymbolHelper.IsInternal(Field);

        internal bool IsProtected => SymbolHelper.IsProtected(Field);
        internal bool IsPrivate => SymbolHelper.IsPrivate(Field);

        internal FieldDefinition(TypeDefinition type, IFieldSymbol symbol)
        {
            Project = type.Project;
            Type = type;
            Field = symbol;
        }

        internal Compilation? GetCompilation()
        {
            return Project?.GetCompilationAsync().Result;
        }

        public override int GetHashCode()
        {
            return new { ProjectName = Project.Name, Name }.GetHashCode();
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
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
