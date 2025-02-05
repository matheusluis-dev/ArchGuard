namespace ArchGuard.Core.Property.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} | Type: {Type.SymbolFullName}")]
    public sealed class PropertyDefinition : IEquatable<PropertyDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public TypeDefinition Type { get; init; }

        private readonly IPropertySymbol _property;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _property.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_property);

        internal bool IsInternal => SymbolHelper.IsInternal(_property);

        internal bool IsProtected => SymbolHelper.IsProtected(_property);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_property);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_property);

        internal bool HasGetMethod => _property.GetMethod is not null;

        internal bool HasSetMethod => _property.SetMethod is not null;

        internal bool IsInitOnly => HasSetMethod && _property.SetMethod!.IsInitOnly;

        internal bool HasCustomBody => PropertySymbolHelper.HasCustomBody(_property);

        internal PropertyDefinition(TypeDefinition type, IPropertySymbol property)
        {
            Project = type.Project;
            Type = type;
            _property = property;
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

        public bool Equals(PropertyDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
