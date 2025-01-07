namespace ArchGuard.Library.Extensions
{
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal static class TypeDeclarationSyntaxExtensions
    {
        internal static string GetFullName(this TypeDeclarationSyntax typeDeclarationSyntax)
        {
            var fullClassName = typeDeclarationSyntax.Identifier.ValueText;

            var parent = typeDeclarationSyntax.Parent;
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
