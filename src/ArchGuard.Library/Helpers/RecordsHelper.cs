namespace ArchGuard.Library.Helpers;

internal static class RecordsHelper
{
    private static readonly Lazy<IEnumerable<string>> _cache = new(LoadRecords);

    internal static IEnumerable<string> Classes => _cache.Value;

    private static IEnumerable<string> LoadRecords()
    {
        return ApplicationCSharpFilesHelper.Files.SelectMany(file =>
        {
            var code = File.ReadAllText(file.FullName);
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var root = syntaxTree.GetRoot();

            return root.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .Where(c => c.Modifiers.Any(m => m.IsKind(SyntaxKind.RecordDeclaration)))
                .Select(c => c.Identifier.Text);
        });
    }
}
