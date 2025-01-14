namespace ArchGuard.Library.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;

    public static class Type_Extensions
    {
        public static bool IsExternallyImmutable(this Type_ type)
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
                    || field.DeclaredAccessibility == Accessibility.Private
                    || field.DeclaredAccessibility == Accessibility.Protected
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
                    || @event.DeclaredAccessibility == Accessibility.Private
                    || @event.DeclaredAccessibility == Accessibility.Protected
                    || @event.AddMethod.IsStatic
                    || @event.AddMethod.DeclaredAccessibility == Accessibility.Private
                    || @event.AddMethod.DeclaredAccessibility == Accessibility.Protected
                );

            if (!allEventsAreExternallyImmutable)
                return false;

            var allMethodsAreExternallyImmutable = symbol
                .GetMembers()
                .OfType<IMethodSymbol>()
                .All(method =>
                    method.IsStatic
                    || method.DeclaredAccessibility == Accessibility.Private
                    || method.DeclaredAccessibility == Accessibility.Protected
                    || !method.ExternallyAltersState(project)
                );

            return allMethodsAreExternallyImmutable;
        }
    }
}
