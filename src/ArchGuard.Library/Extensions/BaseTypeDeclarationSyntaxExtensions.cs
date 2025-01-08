namespace ArchGuard.Library.Extensions
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class BaseTypeDeclarationSyntaxExtensions
    {
        internal static string GetNamespace(
            this BaseTypeDeclarationSyntax baseTypeDeclarationSyntax
        )
        {
            var parent = baseTypeDeclarationSyntax.Parent;
            while (
                parent != null
                && !(parent is BaseNamespaceDeclarationSyntax)
                && !(parent is CompilationUnitSyntax)
            )
            {
                parent = parent.Parent;
            }

            if (parent is BaseNamespaceDeclarationSyntax namespaceDeclarationSyntax)
            {
                return namespaceDeclarationSyntax.Name.ToString();
            }

            return string.Empty;
        }

        internal static string GetName(this BaseTypeDeclarationSyntax baseTypeDeclarationSyntax)
        {
            return baseTypeDeclarationSyntax.Identifier.ValueText;
        }

        internal static string GetFullName(this BaseTypeDeclarationSyntax baseTypeDeclarationSyntax)
        {
            var fullClassName = baseTypeDeclarationSyntax.Identifier.ValueText;

            var parent = baseTypeDeclarationSyntax.Parent;
            while (
                parent != null
                && !(parent is BaseNamespaceDeclarationSyntax)
                && !(parent is CompilationUnitSyntax)
            )
            {
                // Treatment for Nested Classes
                if (parent is ClassDeclarationSyntax parentClass)
                    fullClassName = $"{parentClass.Identifier.ValueText}+{fullClassName}";

                parent = parent.Parent;
            }

            if (parent is BaseNamespaceDeclarationSyntax namespaceDeclarationSyntax)
                fullClassName = $"{namespaceDeclarationSyntax.Name}.{fullClassName}";

            return fullClassName;
        }
    }
}
