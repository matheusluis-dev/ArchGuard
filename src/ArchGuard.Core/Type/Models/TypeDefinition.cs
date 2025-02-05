namespace ArchGuard.Core.Type.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using ArchGuard.Cached;
    using ArchGuard.Core.Field.Models;
    using ArchGuard.Core.Helpers;
    using ArchGuard.Core.Method.Models;
    using Microsoft.CodeAnalysis;

    [DebuggerDisplay("{FullName} | Project: {Project.Name}")]
    public sealed class TypeDefinition : IEquatable<TypeDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public Project Project { get; init; }

        private readonly INamedTypeSymbol _symbol;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => TypeSymbolHelper.GetName(_symbol);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string FullName => TypeSymbolHelper.GetFullName(_symbol);

        internal string Namespace => _symbol.ContainingNamespace.GetFullName();

        internal bool IsPublic => TypeSymbolHelper.IsPublic(_symbol);

        internal bool IsInternal => TypeSymbolHelper.IsInternal(_symbol);

        internal bool IsProtected => SymbolHelper.IsProtected(_symbol);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_symbol);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_symbol);

        internal bool IsFileLocal => TypeSymbolHelper.IsFileLocal(_symbol);

        internal bool IsInterface => _symbol.TypeKind is TypeKind.Interface;

        internal bool IsGenericType => _symbol.IsGenericType;

        internal bool IsImmutable => TypeSymbolHelper.IsImmutable(_symbol);

        internal bool IsStateless => TypeSymbolHelper.IsStateless(_symbol);

        internal IEnumerable<string> SourceFiles =>
            _symbol.Locations.Select(l => l.SourceTree!.FilePath)!;

        internal TypeDefinition(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            _symbol = symbol;
        }

        private IEnumerable<TypeDefinition> GetInterfaces()
        {
            if (!_symbol.AllInterfaces.Any())
                return [];

            return GetAllTypesFromProject()
                .Where(type =>
                    _symbol.AllInterfaces.Any(@interface =>
                        TypeSymbolHelper
                            .GetFullName(@interface)
                            .Equals(type.FullName, StringComparison.Ordinal)
                    )
                );
        }

        internal IEnumerable<TypeDefinition> GetImplementedInterfaces()
        {
            // Interface do not implement another interface
            // Interface inherit another interface
            if (IsInterface)
                return [];

            return GetInterfaces();
        }

        internal IEnumerable<TypeDefinition> GetInheritances()
        {
            return GetAllTypesFromProject()
                .Where(type =>
                    TypeSymbolHelper
                        .Inheritances(_symbol)
                        .Any(symbol =>
                            TypeSymbolHelper
                                .GetFullName(symbol)
                                .Equals(type.FullName, StringComparison.Ordinal)
                        )
                );
        }

        internal Compilation? GetCompilation()
        {
            return Project?.GetCompilationAsync().Result;
        }

        internal IEnumerable<TypeDefinition> GetAllTypesFromProject()
        {
            var compilation = GetCompilation();

            return TypesSearchCached
                .GetAllTypeMembers(compilation!.GlobalNamespace, compilation!.Assembly)
                .Select(type => new TypeDefinition(Project, type));
        }

        internal IEnumerable<TypeDefinition> GetAllTypesFromProject(
            IEnumerable<INamedTypeSymbol> filter
        )
        {
            return GetAllTypesFromProject()
                .Where(type =>
                    filter.Any(a =>
                        TypeSymbolHelper
                            .GetFullName(a)
                            .Equals(type.FullName, StringComparison.Ordinal)
                    )
                );
        }

        internal IEnumerable<IMethodSymbol> GetConstructors()
        {
            return _symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method => method.MethodKind is MethodKind.Constructor);
        }

        internal IEnumerable<MethodDefinition> GetMethods()
        {
            return _symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method =>
                    method.MethodKind is MethodKind.Ordinary && !method.IsImplicitlyDeclared
                )
                .Select(method => new MethodDefinition(this, method));
        }

        internal IEnumerable<FieldDefinition> GetFields()
        {
            return _symbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Select(field => new FieldDefinition(this, field));
        }

        internal IEnumerable<IFieldSymbol> GetConstants()
        {
            return _symbol.GetMembers().OfType<IFieldSymbol>().Where(field => field.IsConst);
        }

        internal IEnumerable<IPropertySymbol> GetProperties()
        {
            return _symbol.GetMembers().OfType<IPropertySymbol>();
        }

        public override int GetHashCode()
        {
            return new { Project.Name, FullName }.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TypeDefinition t)
                return false;

            return Equals(t);
        }

        public bool Equals(TypeDefinition? other)
        {
            return Project.Name.Equals(other?.Project.Name, StringComparison.Ordinal)
                && FullName.Equals(other?.FullName, StringComparison.Ordinal);
        }
    }
}
