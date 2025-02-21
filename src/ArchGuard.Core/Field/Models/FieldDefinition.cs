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
        internal SolutionDefinition Solution { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ProjectDefinition Project { get; init; }

        public TypeDefinition ContainingType { get; init; }

        public TypeDefinition Type =>
            Solution.AllTypes.First(type =>
                type.FullName.Equals(TypeSymbolHelper.GetFullName(_field.Type), StringComparison.Ordinal)
            );

        private readonly IFieldSymbol _field;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _field.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_field);

        internal bool IsInternal => SymbolHelper.IsInternal(_field);

        internal bool IsProtected => SymbolHelper.IsProtected(_field);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_field);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_field);

        internal bool IsReadOnly => _field.IsReadOnly;

        internal bool IsConst => _field.IsConst;

        internal bool IsStatic => _field.IsStatic;

        internal bool IsExternallyImmutable => IsStatic || IsPrivateOrProtected || IsReadOnly || IsConst;

        internal FieldDefinition(
            SolutionDefinition solution,
            ProjectDefinition project,
            TypeDefinition containingType,
            IFieldSymbol field
        )
        {
            Solution = solution;
            Project = project;
            ContainingType = containingType;
            _field = field;
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
