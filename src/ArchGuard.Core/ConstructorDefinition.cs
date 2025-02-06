namespace ArchGuard.Core
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} - {ContainingType.FullName}")]
    public sealed class ConstructorDefinition : IEquatable<ConstructorDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ProjectDefinition Project { get; init; }

        public TypeDefinition ContainingType { get; init; }

        private readonly IMethodSymbol _constructor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _constructor.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_constructor);

        internal bool IsInternal => SymbolHelper.IsInternal(_constructor);

        internal bool IsProtected => SymbolHelper.IsProtected(_constructor);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_constructor);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_constructor);

        internal bool HasParameters => _constructor.Parameters.Any();

        internal TypeDefinition ReturnType =>
            ContainingType
                .GetAllTypesFromProject(_constructor.ReturnType as INamedTypeSymbol)
                .FirstOrDefault();

        internal ConstructorDefinition(
            ProjectDefinition project,
            TypeDefinition containingType,
            IMethodSymbol constructor
        )
        {
            if (constructor.MethodKind is not MethodKind.Constructor)
                throw new ArgumentException("Method is not a Constructor", nameof(constructor));

            Project = project;
            ContainingType = containingType;
            _constructor = constructor;
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

        public bool Equals(ConstructorDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
