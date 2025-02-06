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
        internal SolutionDefinition Solution { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public ProjectDefinition Project { get; init; }

        public TypeDefinition ContainingType { get; init; }

        private readonly IMethodSymbol _method;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string Name => _method.Name;

        internal bool IsPublic => SymbolHelper.IsPublic(_method);

        internal bool IsInternal => SymbolHelper.IsInternal(_method);

        internal bool IsProtected => SymbolHelper.IsProtected(_method);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_method);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_method);

        internal bool IsOrdinary => _method.MethodKind is MethodKind.Ordinary;

        internal bool IsPropertyGet => _method.MethodKind is MethodKind.PropertyGet;

        internal bool IsPropertySet => _method.MethodKind is MethodKind.PropertySet;

        internal bool IsImplicitlyDeclared => _method.IsImplicitlyDeclared;

        internal bool IsAsync => _method.IsAsync;

        internal bool IsStatic => _method.IsStatic;

        internal TypeDefinition ReturnType =>
            Solution.AllTypes.First(type =>
                type.FullName.Equals(
                    TypeSymbolHelper.GetFullName(_method.ReturnType),
                    StringComparison.Ordinal
                )
            );

        internal IEnumerable<TypeDefinition> ParametersTypes
        {
            get
            {
                var parametersTypes = MethodSymbolHelper
                    .GetParametersTypes(_method)
                    .Select(TypeSymbolHelper.GetFullName);

                return Solution.AllTypes.Where(type =>
                    parametersTypes.Any(parameterTypeName =>
                        type.FullName.Equals(parameterTypeName, StringComparison.Ordinal)
                    )
                );
            }
        }

        internal IEnumerable<TypeDefinition> TypesInBody
        {
            get
            {
                var typesInBody = MethodSymbolHelper
                    .GetTypesInBody(Project, _method)
                    .Select(TypeSymbolHelper.GetFullName);

                return Solution.AllTypes.Where(type =>
                    typesInBody.Any(parameterTypeName =>
                        type.FullName.Equals(parameterTypeName, StringComparison.Ordinal)
                    )
                );
            }
        }

        internal bool IsExternallyImmutable(bool ignorePrivateOrProtectedVerification = false)
        {
            if (IsImplicitlyDeclared)
                return false;

            if (!IsOrdinary && !IsPropertyGet && !IsPropertySet)
                return false;

            if (GetTypesAssignedInBody().Any())
                return false;

            return true;
        }

        internal MethodDefinition(
            SolutionDefinition solution,
            ProjectDefinition project,
            TypeDefinition containingType,
            IMethodSymbol method
        )
        {
            if (method.MethodKind is MethodKind.Constructor)
            {
                throw new ArgumentException(
                    $"Constructors must be created with {nameof(ConstructorDefinition)}"
                );
            }

            Solution = solution;
            Project = project;
            ContainingType = containingType;
            _method = method;
        }

        internal IEnumerable<TypeDefinition> GetTypesAssignedInBody()
        {
            var assignmentTypes = MethodSymbolHelper
                .GetAssignmentsTypes(Project, _method)
                .Select(TypeSymbolHelper.GetFullName);

            return Solution.AllTypes.Where(type =>
                assignmentTypes.Contains(type.FullName, StringComparer.Ordinal)
            );
        }

        internal IEnumerable<TypeDefinition> GetDependencies()
        {
            var dependencies = MethodSymbolHelper
                .GetDependencies(Project, _method)
                .Select(TypeSymbolHelper.GetFullName);

            return Solution.AllTypes.Where(type =>
                dependencies.Any(dependencyName =>
                    type.FullName.Equals(dependencyName, StringComparison.Ordinal)
                )
            );
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
