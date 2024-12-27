namespace ArchGuard.Library.Helpers;

internal static class PartialHelper
{
    private static readonly Lazy<IEnumerable<string>> _cache = new(Load);

    internal static IEnumerable<string> Types => _cache.Value;

    private static IEnumerable<string> Load()
    {
        return ApplicationCSharpFilesHelper.Files.SelectMany(file =>
        {
            var code = File.ReadAllText(file.FullName);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot();

            return root.DescendantNodes()
                .OfType<TypeDeclarationSyntax>()
                .Where(c => c.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)))
                .Select(c => c.GetFullName());
        });
    }
}
