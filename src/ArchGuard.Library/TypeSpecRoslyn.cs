namespace ArchGuard.Library
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using ArchGuard.Library.Extensions;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    [DebuggerDisplay("{FullName}")]
    public sealed class TypeSpecRoslyn
    {
        private readonly BaseTypeDeclarationSyntax _typeDeclaration;
        public string FileName { get; }

        public bool IsClass => _typeDeclaration is ClassDeclarationSyntax;

        public bool IsRecord => _typeDeclaration is RecordDeclarationSyntax;

        public bool IsInterface => _typeDeclaration is InterfaceDeclarationSyntax;

        public bool IsStruct => _typeDeclaration is StructDeclarationSyntax;

        public bool IsEnum => _typeDeclaration is EnumDeclarationSyntax;

        public bool IsPublic =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword));

        public bool IsInternal =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.InternalKeyword));

        public bool IsPrivate =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.PrivateKeyword));

        public bool IsProtected =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.ProtectedKeyword));

        public bool IsFileScoped =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.FileKeyword));

        public bool IsPartial =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

        public bool IsSealed =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.SealedKeyword));

        public bool IsStatic =>
            _typeDeclaration.Modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword));

        public bool IsNested => _typeDeclaration.Parent is BaseTypeDeclarationSyntax;

        public bool IsGeneric =>
            _typeDeclaration is TypeDeclarationSyntax typeDeclarationSyntax
            && typeDeclarationSyntax.TypeParameterList != null;

        public string Namespace => _typeDeclaration.GetNamespace();

        public string Name => _typeDeclaration.GetName();

        public string FullName => _typeDeclaration.GetFullName();

        public IEnumerable<string> InterfacesImplemented
        {
            get
            {
                var implementedInterfaces = new List<string>();

                if (_typeDeclaration.BaseList != null)
                {
                    foreach (var baseType in _typeDeclaration.BaseList.Types)
                    {
                        var typeSymbol = baseType.Type;
                        if (typeSymbol is IdentifierNameSyntax identifierNameSyntax)
                        {
                            implementedInterfaces.Add(identifierNameSyntax.Identifier.Text);
                        }
                        else if (typeSymbol is QualifiedNameSyntax qualifiedNameSyntax)
                        {
                            implementedInterfaces.Add(qualifiedNameSyntax.ToString());
                        }
                    }
                }

                return implementedInterfaces;
            }
        }

        public TypeSpecRoslyn(BaseTypeDeclarationSyntax baseTypeDeclarationSyntax, string fileName)
        {
            _typeDeclaration = baseTypeDeclarationSyntax;
            FileName = fileName;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is TypeSpecRoslyn other))
                return false;

            return FullName.Equals(other.FullName, StringComparison.Ordinal)
                && FileName.Equals(other.FileName, StringComparison.Ordinal);
        }

        public override int GetHashCode()
        {
            return new { FullName, FileName }.GetHashCode();
        }
    }
}
