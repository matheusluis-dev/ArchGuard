namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ArchGuard.Library.Cached;
    using Microsoft.CodeAnalysis;

    internal static class TypeDefinitionExtensions
    {
        internal static bool IsExternallyImmutable(this TypeDefinition type)
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

        internal static bool IsUsedBy(this TypeDefinition typeDefinition, IEnumerable<string> types)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition);
            ArgumentNullException.ThrowIfNull(types);

            foreach (var type in typeDefinition.GetAllTypesFromProject())
            {
                var dependencies = type.GetDependencies().Select(type => type.Symbol.GetFullName());

                if (dependencies.Any(d => types.Contains(d, StringComparer.Ordinal)))
                    return true;
            }

            return false;
        }
    }
}
