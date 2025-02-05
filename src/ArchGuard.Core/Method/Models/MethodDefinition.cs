namespace ArchGuard.Core.Method.Models
{
    using System;
    using System.Diagnostics;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Type.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{Name} | Type: {Type.SymbolFullName}")]
    public sealed class MethodDefinition : IEquatable<MethodDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        public TypeDefinition Type { get; init; }

        private readonly IMethodSymbol _method;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => _method.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_method);

        internal bool IsInternal => SymbolHelper.IsInternal(_method);

        internal bool IsProtected => SymbolHelper.IsProtected(_method);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_method);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_method);

        internal MethodDefinition(TypeDefinition type, IMethodSymbol symbol)
        {
            Project = type.Project;
            Type = type;
            _method = symbol;
        }

        internal IEnumerable<TypeDefinition> GetTypesAssignedInBody()
        {
            return Type.GetAllTypesFromProject(
                MethodSymbolHelper.GetAssignmentsTypes(Project, _method)
            );
        }

        internal IEnumerable<TypeDefinition> GetPropertiesAccessorsTypes()
        {
            return Type.GetAllTypesFromProject(
                MethodSymbolHelper.GetPropertiesAccessorsTypes(Project, _method)
            );
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

        public bool Equals(MethodDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && Name.Equals(other?.Name, StringComparison.Ordinal);
        }
    }
}
