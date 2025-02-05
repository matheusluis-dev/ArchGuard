namespace ArchGuard.Core.Helpers
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class PropertySymbolHelper
    {
        internal static bool HasCustomBody(IPropertySymbol propertySymbol)
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
    }
}
