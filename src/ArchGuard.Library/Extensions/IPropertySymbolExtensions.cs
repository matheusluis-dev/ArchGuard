namespace ArchGuard.Extensions
{
    using System;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public static class IPropertySymbolExtensions
    {
        public static bool HasGetMethod(this IPropertySymbol propertySymbol)
        {
            ArgumentNullException.ThrowIfNull(propertySymbol);

            return propertySymbol.GetMethod is not null;
        }

        public static bool HasSetMethod(this IPropertySymbol propertySymbol)
        {
            ArgumentNullException.ThrowIfNull(propertySymbol);

            return propertySymbol.SetMethod is not null;
        }

        public static bool HasCustomBody(this IPropertySymbol propertySymbol)
        {
            ArgumentNullException.ThrowIfNull(propertySymbol);

            var syntaxReference = propertySymbol.DeclaringSyntaxReferences.FirstOrDefault();
            if (syntaxReference is null)
                return false;

            if (syntaxReference.GetSyntax() is not PropertyDeclarationSyntax propertySyntax)
                return false;

            var accessors = propertySyntax.AccessorList?.Accessors;

            return accessors?.Any(a => a.Body is not null || a.ExpressionBody is not null) == true;
        }

        public static bool IsExternallyImmutable(
            this IPropertySymbol propertySymbol,
            Project project,
            bool ignorePrivateOrProtectedVerification = false
        )
        {
            ArgumentNullException.ThrowIfNull(propertySymbol);

            if (propertySymbol.IsStatic)
                return true;

            if (!ignorePrivateOrProtectedVerification && propertySymbol.IsPrivateOrProtected())
                return true;

            if (!propertySymbol.HasCustomBody())
                return true;

            var getImmutable = true;
            if (propertySymbol.HasGetMethod())
            {
                getImmutable =
                    propertySymbol!.GetMethod!.IsPrivateOrProtected()
                    && !propertySymbol!.GetMethod!.ExternallyAltersState(project);
            }

            var setImmutable = true;
            if (propertySymbol.HasSetMethod())
            {
                setImmutable =
                    propertySymbol!.SetMethod!.IsInitOnly
                    ||
                        propertySymbol.SetMethod.IsPrivateOrProtected()
                        && !propertySymbol.SetMethod.ExternallyAltersState(project)
                    ;
            }

            return getImmutable && setImmutable;
        }
    }
}
