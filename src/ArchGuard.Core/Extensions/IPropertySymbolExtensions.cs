namespace ArchGuard.Extensions
{
    using System;
    using System.Linq;
    using ArchGuard.Core.Helpers;
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

       

        public static bool IsExternallyImmutable(
            this IPropertySymbol propertySymbol,
            Project project,
            bool ignorePrivateOrProtectedVerification = false
        )
        {
            ArgumentNullException.ThrowIfNull(propertySymbol);

            if (propertySymbol.IsStatic)
                return true;

            if (
                !ignorePrivateOrProtectedVerification
                && SymbolHelper.IsPrivateOrProtected(propertySymbol)
            )
            {
                return true;
            }

            if (!propertySymbol.HasCustomBody())
                return true;

            var getImmutable = true;
            if (propertySymbol.HasGetMethod())
            {
                getImmutable =
                    SymbolHelper.IsPrivateOrProtected(propertySymbol!.GetMethod!)
                    && !propertySymbol!.GetMethod!.ExternallyAltersState(project);
            }

            var setImmutable = true;
            if (propertySymbol.HasSetMethod())
            {
                setImmutable =
                    propertySymbol!.SetMethod!.IsInitOnly
                    || (
                        SymbolHelper.IsPrivateOrProtected(propertySymbol.SetMethod)
                        && !propertySymbol.SetMethod.ExternallyAltersState(project)
                    );
            }

            return getImmutable && setImmutable;
        }
    }
}
