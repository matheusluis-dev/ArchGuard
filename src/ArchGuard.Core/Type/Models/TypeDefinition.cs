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
    using ArchGuard.Core.Property.Models;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [DebuggerDisplay("{FullName} | Project: {Project.Name}")]
    public sealed class TypeDefinition : IEquatable<TypeDefinition>
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal ProjectDefinition Project { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => TypeSymbolHelper.GetName(_type);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public string FullName => TypeSymbolHelper.GetFullName(_type);

        internal string Namespace => NamespaceSymbolHelper.GetFullName(_type.ContainingNamespace);

        internal bool IsPartial =>
            _type
                .DeclaringSyntaxReferences.Select(reference => reference.GetSyntax())
                .OfType<TypeDeclarationSyntax>()
                .Any(syntax => syntax.Modifiers.Any(SyntaxKind.PartialKeyword));

        internal bool IsSealed => _type.IsSealed;

        internal bool IsNested => _type.ContainingType is not null;

        internal bool IsStatic => _type.IsStatic;

        internal bool IsAbstract => _type.IsAbstract;

        internal bool IsPublic => TypeSymbolHelper.IsPublic(_type);

        internal bool IsInternal => TypeSymbolHelper.IsInternal(_type);

        internal bool IsProtected => SymbolHelper.IsProtected(_type);

        internal bool IsPrivate => SymbolHelper.IsPrivate(_type);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(_type);

        internal bool IsFileLocal => TypeSymbolHelper.IsFileLocal(_type);

        internal bool IsGenericType => _type.IsGenericType;

        internal bool IsImmutable => TypeSymbolHelper.IsImmutable(_type);

        internal bool IsStateless => TypeSymbolHelper.IsStateless(_type);

        internal bool IsStaticless => TypeSymbolHelper.IsStaticless(_type);

        internal bool IsClass => _type.TypeKind is TypeKind.Class && !IsRecord;

        internal bool IsRecord => _type.IsRecord && _type.TypeKind is not TypeKind.Struct;

        internal bool IsInterface => _type.TypeKind is TypeKind.Interface;

        internal bool IsStruct => _type.TypeKind is TypeKind.Struct && !IsRecordStruct;

        internal bool IsRecordStruct =>
            _type.TypeKind is TypeKind.Struct or TypeKind.Structure && _type.IsRecord;

        internal bool IsEnum => _type.TypeKind is TypeKind.Enum;

        internal IEnumerable<string> SourceFiles =>
            _type
                .Locations.Where(l => l.SourceTree is not null)
                .Select(l => l.SourceTree!.FilePath);

        internal bool SourceFilePathMatchesNamespace(StringComparison comparison)
        {
            if (!SourceFiles.Any())
                return false;

            var separator = Path.DirectorySeparatorChar;

            foreach (var file in SourceFiles)
            {
                var directory = Path.GetDirectoryName(file);

                var lastIndexSeparatorAtEnd = directory!.LastIndexOf(
                    separator + Project.DefaultNamespace + separator,
                    comparison
                );

                var lastIndexSeparatorAtStartOnly = directory.LastIndexOf(
                    separator + Project.DefaultNamespace + separator,
                    comparison
                );

                var lastIndex =
                    lastIndexSeparatorAtEnd > -1
                        ? lastIndexSeparatorAtEnd
                        : lastIndexSeparatorAtStartOnly;

                var filePathNormalized = directory[(lastIndex + 1)..].Replace(separator, '.');

                if (Namespace.Equals(filePathNormalized, comparison))
                    return true;
            }

            return false;
        }

        internal bool SourceFileNameMatchesTypeName(StringComparison comparison)
        {
            if (!SourceFiles.Any())
                return false;

            return SourceFiles.Any(file =>
                Path.GetFileNameWithoutExtension(file).Equals(Name, comparison)
            );
        }

        private readonly DependencyFinder _dependencySearch;
        private readonly INamedTypeSymbol _type;

        internal TypeDefinition(
            DependencyFinder dependencySearch,
            ProjectDefinition project,
            INamedTypeSymbol symbol
        )
        {
            _dependencySearch = dependencySearch;
            Project = project;
            _type = symbol;
        }

        private IEnumerable<TypeDefinition> GetInterfaces()
        {
            if (!_type.AllInterfaces.Any())
                return [];

            return GetAllTypesFromProject()
                .Where(type =>
                    _type.AllInterfaces.Any(@interface =>
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
                        .Inheritances(_type)
                        .Any(symbol =>
                            TypeSymbolHelper
                                .GetFullName(symbol)
                                .Equals(type.FullName, StringComparison.Ordinal)
                        )
                );
        }

        internal IEnumerable<TypeDefinition> GetAllTypesFromProject()
        {
            var compilation = Project.Compilation;

            return TypesLoader
                .GetAllTypeMembers(compilation!.GlobalNamespace, compilation!.Assembly)
                .Select(type => new TypeDefinition(_dependencySearch, Project, type));
        }

        internal IEnumerable<TypeDefinition> GetAllTypesFromProject(
            params IEnumerable<INamedTypeSymbol> filter
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

        internal IEnumerable<ConstructorDefinition> GetConstructors()
        {
            return _type
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(constructor => constructor.MethodKind is MethodKind.Constructor)
                .Select(constructor => new ConstructorDefinition(Project, this, constructor));
        }

        internal IEnumerable<MethodDefinition> GetMethods()
        {
            return _type
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method =>
                    method.MethodKind is MethodKind.Ordinary && !method.IsImplicitlyDeclared
                )
                .Select(method => new MethodDefinition(Project, this, method));
        }

        internal IEnumerable<FieldDefinition> GetFields()
        {
            return _type
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Select(field => new FieldDefinition(Project, this, field));
        }

        internal IEnumerable<IFieldSymbol> GetConstants()
        {
            return _type.GetMembers().OfType<IFieldSymbol>().Where(field => field.IsConst);
        }

        internal IEnumerable<PropertyDefinition> GetProperties()
        {
            return _type
                .GetMembers()
                .OfType<IPropertySymbol>()
                .Select(property => new PropertyDefinition(Project, this, property));
        }

        internal IEnumerable<TypeDefinition> GetDependencies()
        {
            return _dependencySearch.GetDependencies(this);
        }

        internal bool IsExternallyImmutable()
        {
            if (GetFields().Any(field => !field.IsExternallyImmutable))
                return false;

            //if (GetProperties().Any(property => property.isExternallyImmutable))

            return true;
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
