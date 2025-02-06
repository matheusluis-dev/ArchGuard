namespace ArchGuard.Core.Method.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} - {ContainingType.FullName}")]
    public sealed class MethodDefinition : IEquatable<MethodDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ProjectDefinition Project { get; init; }

        public TypeDefinition ContainingType { get; init; }

        private readonly IMethodSymbol _method;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _method.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_method);

        internal bool IsInternal => SymbolHelper.IsInternal(_method);

        internal bool IsProtected => SymbolHelper.IsProtected(_method);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_method);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_method);

        internal bool IsAsync => _method.IsAsync;

        internal bool IsStatic => _method.IsStatic;

        internal TypeDefinition ReturnType =>
            ContainingType
                .GetAllTypesFromProject(_method.ReturnType as INamedTypeSymbol)
                .FirstOrDefault();

        internal bool IsExternallyImmutable(bool ignorePrivateOrProtectedVerification = false)
        {
            if (GetTypesAssignedInBody().Any())
                return false;

            return true;
        }

        internal MethodDefinition(
            ProjectDefinition project,
            TypeDefinition containingType,
            IMethodSymbol method
        )
        {
            Project = project;
            ContainingType = containingType;
            _method = method;
        }

        internal IEnumerable<TypeDefinition> GetTypesAssignedInBody()
        {
            return ContainingType.GetAllTypesFromProject(
                MethodSymbolHelper.GetAssignmentsTypes(Project, _method)
            );
        }

        internal IEnumerable<TypeDefinition> GetPropertiesAccessorsTypes()
        {
            return ContainingType.GetAllTypesFromProject(
                MethodSymbolHelper.GetPropertiesAccessorsTypes(Project, _method)
            );
        }

        internal IEnumerable<TypeDefinition> GetDependencies()
        {
            // TODO
            throw new NotImplementedException();
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

        public bool Equals(MethodDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
