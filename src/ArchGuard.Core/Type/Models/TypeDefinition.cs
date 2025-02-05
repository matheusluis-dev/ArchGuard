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

        public INamedTypeSymbol Symbol { get; init; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string Name => TypeSymbolHelper.GetName(Symbol);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal string FullName => TypeSymbolHelper.GetFullName(Symbol);

        internal bool IsPublic => TypeSymbolHelper.IsPublic(Symbol);

        internal bool IsInternal => TypeSymbolHelper.IsInternal(Symbol);

        internal bool IsProtected => SymbolHelper.IsProtected(Symbol);

        internal bool IsPrivate => SymbolHelper.IsPrivate(Symbol);

        internal bool IsPrivateOrProtected => SymbolHelper.IsPrivateOrProtected(Symbol);

        internal bool IsFileLocal => TypeSymbolHelper.IsFileLocal(Symbol);

        internal bool IsInterface => Symbol.TypeKind is TypeKind.Interface;

        internal TypeDefinition(Project project, INamedTypeSymbol symbol)
        {
            Project = project;
            Symbol = symbol;
        }

        private IEnumerable<TypeDefinition> GetInterfaces()
        {
            if (!Symbol.AllInterfaces.Any())
                return [];

            return GetAllTypesFromProject()
                .Where(type =>
                    Symbol.AllInterfaces.Any(@interface =>
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
                        .Inheritances(Symbol)
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

        internal IEnumerable<IMethodSymbol> GetConstructors()
        {
            return Symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method => method.MethodKind is MethodKind.Constructor);
        }

        internal IEnumerable<MethodDefinition> GetMethods()
        {
            return Symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .Where(method =>
                    method.MethodKind is MethodKind.Ordinary && !method.IsImplicitlyDeclared
                )
                .Select(method => new MethodDefinition(this, method));
        }

        internal IEnumerable<FieldDefinition> GetFields()
        {
            return Symbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .Select(field => new FieldDefinition(this, field));
        }

        internal IEnumerable<IFieldSymbol> GetConstants()
        {
            return Symbol.GetMembers().OfType<IFieldSymbol>().Where(field => field.IsConst);
        }

        internal IEnumerable<IPropertySymbol> GetProperties()
        {
            return Symbol.GetMembers().OfType<IPropertySymbol>();
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
