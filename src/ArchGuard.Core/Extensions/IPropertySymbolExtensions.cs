namespace ArchGuard.Core.Extensions
{
    using System;
    using ArchGuard.Core;
    using ArchGuard.Core.Helpers;
    using Microsoft.CodeAnalysis;

    public static class IPropertySymbolExtensions
    {
        public static bool IsExternallyImmutable(
            this IPropertySymbol propertySymbol,
            ProjectDefinition project,
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
                    || SymbolHelper.IsPrivateOrProtected(propertySymbol.SetMethod)
                        && !propertySymbol.SetMethod.ExternallyAltersState(project);
            }

            return getImmutable && setImmutable;
        }
    }
}
