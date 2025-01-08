namespace ArchGuard.Library.Type
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using ArchGuard.Library.Helpers;
    using ArchGuard.Library.Type.Filters;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public sealed class Types
    {
        private Types() { }

        public static ITypesFilterStart FromAssembly(Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));

            var assemblySpec = new AssemblySpec(assembly);
            var types = AssemblyFilesReaderHelper
                .GetFiles(assemblySpec)
                .SelectMany(file =>
                {
                    var code = File.ReadAllText(file.FullName);
                    var syntaxTree = CSharpSyntaxTree.ParseText(
                        code,
                        new CSharpParseOptions().WithPreprocessorSymbols(
                            "NET5_0_OR_GREATER",
                            "NET7_0_OR_GREATER"
                        )
                    );
                    var root = syntaxTree.GetRoot();

                    return root.DescendantNodes()
                        .OfType<BaseTypeDeclarationSyntax>()
                        .Select(t => new TypeSpecRoslyn(t, file.FullName));
                });

            var context = new TypesFilterContext(types);

            return TypesFilter.Create(context);
        }
    }
}
