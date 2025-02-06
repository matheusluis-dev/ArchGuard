namespace ArchGuard.Core.Property.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Method.Models;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} | Type: {Type.SymbolFullName}")]
    public sealed class PropertyDefinition : IEquatable<PropertyDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ProjectDefinition Project { get; init; }

        public TypeDefinition ContainingType { get; init; }
        public TypeDefinition Type => throw new NotImplementedException();

        private readonly IPropertySymbol _property;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _property.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_property);

        internal bool IsInternal => SymbolHelper.IsInternal(_property);

        internal bool IsProtected => SymbolHelper.IsProtected(_property);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_property);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_property);

        internal bool HasGetMethod => _property.GetMethod is not null;

        internal MethodDefinition? GetMethod =>
            HasGetMethod
                ? new MethodDefinition(Project, ContainingType, _property.GetMethod!)
                : null;

        internal bool HasSetMethod => _property.SetMethod is not null;

        internal MethodDefinition? SetMethod =>
            HasSetMethod
                ? new MethodDefinition(Project, ContainingType, _property.SetMethod!)
                : null;

        internal bool IsInitOnly => HasSetMethod && _property.SetMethod!.IsInitOnly;

        internal bool HasCustomBody => PropertySymbolHelper.HasCustomBody(_property);

        internal bool IsStatic => _property.IsStatic;

        internal bool IsExternallyImmutable(bool ignorePrivateOrProtectedVerification = false)
        {
            // TODO: ignore properties with backing fields

            if (IsStatic)
                return true;

            if (!ignorePrivateOrProtectedVerification && IsPrivateOrProtected)
                return true;

            if (!HasCustomBody)
                return true;

            if (!IsPrivateOrProtected || GetMethod?.IsExternallyImmutable() == false)
                return false;

            if (!IsInitOnly || !IsPrivateOrProtected || SetMethod?.IsExternallyImmutable() == false)
                return false;

            return true;
        }

        internal PropertyDefinition(
            ProjectDefinition project,
            TypeDefinition containingType,
            IPropertySymbol property
        )
        {
            Project = project;
            ContainingType = containingType;
            _property = property;
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

        public bool Equals(PropertyDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
