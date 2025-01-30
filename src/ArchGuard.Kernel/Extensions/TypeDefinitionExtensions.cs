namespace ArchGuard.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Cached;
    using ArchGuard.Kernel.Models;
    using Microsoft.CodeAnalysis;

    public static class TypeDefinitionExtensions
    {
        public static IEnumerable<INamedTypeSymbol> GetContainingTypes(this TypeDefinition type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var symbols = new List<INamedTypeSymbol>();
            var current = type.Symbol.ContainingType;
            while (current != null)
            {
                symbols.Add(current);
                current = current.ContainingType;
            }

            return symbols;
        }

        public static IEnumerable<INamedTypeSymbol> GetContainingTypesAndSelf(
            this TypeDefinition type
        )
        {
            ArgumentNullException.ThrowIfNull(type);

            var symbols = new List<INamedTypeSymbol> { type.Symbol };

            symbols.AddRange(type.GetContainingTypes());

            return symbols;
        }

        public static bool IsPublic(this TypeDefinition type)
        {
            ArgumentNullException.ThrowIfNull(type);

            return type.GetContainingTypesAndSelf()
                .All(symbol => symbol.DeclaredAccessibility is Accessibility.Public);
        }

        public static bool IsInternal(this TypeDefinition type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var typeIsInternal =
                !type.Symbol.IsFileLocal
                && type.Symbol.DeclaredAccessibility
                    is Accessibility.Internal
                        or Accessibility.Friend
                        or Accessibility.ProtectedOrFriend
                        or Accessibility.ProtectedOrInternal;

            if (!typeIsInternal)
                return false;

            foreach (var symbol in type.GetContainingTypes())
            {
                var containingTypeIsCompliant =
                    !symbol.IsFileLocal
                    && symbol.DeclaredAccessibility
                        is not Accessibility.NotApplicable
                            and not Accessibility.Protected
                            and not Accessibility.Private;

                if (!containingTypeIsCompliant)
                    return false;
            }

            return true;
        }

        public static bool IsExternallyImmutable(this TypeDefinition type)
        {
            ArgumentNullException.ThrowIfNull(type);

            var project = type.Project;
            var symbol = type.Symbol;

            // Constructors can be ignored
            // They must be able to fill readonly fields and init properties

            // Operators can be ignored, always static

            // Finalizers/Destructors can be ignored, they can't be called

            var allFieldsAreExternallyImmutable = symbol
                .GetMembers()
                .OfType<IFieldSymbol>()
                .All(field =>
                    field.IsStatic
                    || field.IsPrivateOrProtected()
                    || field.IsReadOnly
                    || field.IsConst
                );

            if (!allFieldsAreExternallyImmutable)
                return false;

            // Indexers are checked here
            var allPropertiesAreExternallyImmutable = symbol
                .GetMembers()
                .OfType<IPropertySymbol>()
                .All(property => property.IsExternallyImmutable(project));

            if (!allPropertiesAreExternallyImmutable)
                return false;

            var allEventsAreExternallyImmutable = symbol
                .GetMembers()
                .OfType<IEventSymbol>()
                .All(@event =>
                    @event.IsStatic
                    || @event.IsPrivateOrProtected()
                    || @event.AddMethod?.IsStatic == true
                    || @event.AddMethod?.IsPrivateOrProtected() == true
                );

            if (!allEventsAreExternallyImmutable)
                return false;

            return symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .All(method =>
                    method.IsStatic
                    || method.IsPrivateOrProtected()
                    || !method.ExternallyAltersState(project)
                );
        }

        public static IEnumerable<TypeDefinition> GetDependencies(
            this TypeDefinition typeDefinition
        )
        {
            ArgumentNullException.ThrowIfNull(typeDefinition);

            return DependencySearchCached.GetDependencies(typeDefinition);
        }

        public static bool IsUsedBy(this TypeDefinition typeDefinition, IEnumerable<string> types)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition);
            ArgumentNullException.ThrowIfNull(types);

            var allTypes = typeDefinition.GetAllTypesFromProject();

            var typesToCheck = allTypes.Where(type =>
                types.Contains(type.SymbolFullName, StringComparer.Ordinal)
            );

            foreach (var type in typesToCheck)
            {
                var dependencies = type.GetDependencies();

                if (dependencies.Any(dependency => dependency.Equals(typeDefinition)))
                    return true;
            }

            return false;
        }
    }
}
